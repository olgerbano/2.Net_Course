using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace IPC
{
    // This is called when a client has made a call. The first parameter is the command from the
    // client (including any parameters of that command), the second parameter is a dictionary
    // created by the event caller, but filled by the event handler with any results.
    public delegate void ReceivedCommandDelegate(string command, IList<KeyValuePair<string, string>> results);

    // This creates a thread to listen for connections. When a connection is accepted this
    // class creates a separate thread for the client socket and then loops accepting
    // commands from the client and returning any results from executing this commands.
    public class ServerSide
    {
        int port;
        ManualResetEvent mreStop;

        // This *must* be implemented by the server code. It is called when a client makes a call.
        public event ReceivedCommandDelegate ReceivedCommand;

        // Provide the socket port 
        public ServerSide(int port)
        {
            this.port = port;
            mreStop = new ManualResetEvent(false);
        }

        // This creates the end point and binds a socket to the local machine. It then starts
        // listening for connections on a thread pool thread.
        public void Listen()
        {
            IPEndPoint ep = new IPEndPoint(Dns.GetHostEntry("").AddressList[0], port);
            Socket workerSocket = new Socket(ep.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            workerSocket.Bind(ep);
            // Indicate that internally 100 request will be queued
            workerSocket.Listen(100);
            // Start the listening thread
            ThreadPool.QueueUserWorkItem(new WaitCallback(AcceptCallback), workerSocket);
        }

        // This will tell the listening thread, and any worker threads, to stop their work
        public void StopListening()
        {
            mreStop.Set();
        }

        // This handles the incoming calls by starting a new thread for each new connection.
        // This thread will end if the event object is set.
        private void AcceptCallback(object obj)
        {
            Socket workerSocket = obj as Socket;
            while (true)
            {
                // See if we should stop listening
                if (mreStop.WaitOne(0, false))
                {
                    CleanUp(workerSocket);
                    return; // This thread will die
                }

                // Get the client socket and pass it to another thread.
                Socket clientSocket = workerSocket.Accept();
                ThreadPool.QueueUserWorkItem(new WaitCallback(HandleConnection), clientSocket);
            }
        }

        // This handles the client connection. It assumes that the client will send a command and
        // expect a reply. The reply will be a dictionary of serialisable objects.
        private void HandleConnection(object obj)
        {
            Socket workerSocket = obj as Socket;

            // Loop until we are told to stop, either by the ServerSide object
            // or by the client
            while (true)
            {
                // Wait until there is data on the socket
                while (workerSocket.Available == 0 && !mreStop.WaitOne(0, false))
                {
                    // This thread just handles this socket, so it does not matter if it blocks.
                    Thread.Sleep(100);
                }

                // See if we should stop listening
                if (mreStop.WaitOne(0, false))
                {
                    break; // This thread will die
                }
 
                // Read the command passed by the client and convert it to a string.
                byte[] buffer = new byte[workerSocket.Available];
                int count = workerSocket.Receive(buffer);
                string command = Encoding.ASCII.GetString(buffer, 0, count);

                if (command == "END")
                {
                    // if the client sends an END command stop this thread.
                    break; // This thread will die
                }

                // This object will be filled with results by the handler
                IList<KeyValuePair<string, string>> results = new List<KeyValuePair<string, string>>();
                // Call the handlers, this will block
                ReceivedCommand.Invoke(command, results);

                // Serialize the results, so that they can be returne to the client.
                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream stm = new MemoryStream();
                formatter.Serialize(stm, results);
                byte[] buf = stm.GetBuffer();
                // Send the results back to the client, stm.Length is the number of bytes written
                // into the stream.
                workerSocket.Send(buf, (int)stm.Length, SocketFlags.None);
                // Loop, and wait for the client to send another command.
            }

            CleanUp(workerSocket);
        }

        // Clean up the socket object
        private void CleanUp(Socket socket)
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
    }

    // This class uses sockets to talk to the server side socket.
    public class ClientSide : IDisposable
    {
        int port;
        Socket socket;
        IPEndPoint ep;

        // Create the endpoint to bind to
        public ClientSide(int port)
        {
            this.port = port;
            ep = new IPEndPoint(Dns.GetHostEntry("").AddressList[0], port);
        }

        // Create the endpoint to bind to
        public ClientSide(string host, int port)
        {
            this.port = port;
            ep = new IPEndPoint(Dns.GetHostEntry(host).AddressList[0], port);
        }

        // Create the socket and connect to it.
        public void Connect()
        {
            if (socket != null) Disconnect();
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ep);
        }

        // The client has finished with the socket so tear down the infrastructure
        public void Disconnect()
        {
            if (socket == null) return;
            Send("END");
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
            socket = null;
        }

        // Send the string command to the socket and retrieve the results. Return the 
        // results to the caller.
        public IList<KeyValuePair<string, string>> Send(string str)
        {
            if (socket == null) return null;
            byte[] buf = null;
            try
            {
                // Send the command to the server
                buf = Encoding.ASCII.GetBytes(str);
                socket.Send(buf); // Synchronous

                // If the command tells the server to die, then we don't wait for a reply.
                if (str == "END") return null;

                // Wait for the result
                while (socket.Available == 0)
                {
                    // Not sure who will call this method, so allow COM and message queue pumping
                    Thread.CurrentThread.Join(0);
                }

                buf = new byte[socket.Available];
                socket.Receive(buf); // Synchronous
            }
            catch (InvalidOperationException)
            {
                return null;
            }

            if (buf == null) return new List<KeyValuePair<string, string>>();

            // buf will contain the serialized dictionary, so deserialize
            MemoryStream stm = new MemoryStream(buf);
            string test = Encoding.ASCII.GetString(buf);
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(stm) as IList<KeyValuePair<string, string>>;
        }

        // Just in case we have forgotten to call Disconnect...
        public void Dispose()
        {
            if (socket != null) Disconnect();
        }
    }
}
