using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Text;
using System.Windows.Forms;
using IPC;

namespace FileWatcherClient
{
    public partial class MainForm : Form
    {
        ClientSide client;

        // Communication with the service is on another thread. This object is used to
        // allow the thread to update the user interface.
        SynchronizationContext ctx;
        // Two events to provide inter-thread communication.
        ManualResetEvent mreDead;  // Used to tell the main thread that the worker thread has finished
        AutoResetEvent areNewData; // Used to indicate that there is a new command
        // This is used to indicate that the worker thread should die
        bool bStayAlive;

        // The following are data passed from the UI thread to the worker thread
        enum Command { Start, Stop, Reset, Results };
        Command cmd;               // This is the command to pass
        string watchFolder = null; // This is the folder to watch
        int id;                    // This is the ID that is unique for this process instance

        public MainForm()
        {
            InitializeComponent();

            // Get the context for the user interface.
            ctx = SynchronizationContext.Current;
            client = new ClientSide(5000);
            bStayAlive = true;
            mreDead = new ManualResetEvent(false);
            areNewData = new AutoResetEvent(false);
            // Get a unique ID for this client.
            id = System.Diagnostics.Process.GetCurrentProcess().Handle.ToInt32();
            // Start the worker thread.
            ThreadPool.QueueUserWorkItem(new WaitCallback(ListeningThread), null);
        }

        // This thread will loop waiting for one of two actions. 
        // 1) If bStayAlive is set false then the thread should die.
        // 2) If areNewData is set then there is new command to be processed.
        private void ListeningThread(object obj)
        {
            // Get the client socket.
            client.Connect();
            while (true)
            {
                // Sleep until there is new data
                areNewData.WaitOne();
                if (!bStayAlive) break; // The thread has been told to finish.
                string strCmd = null;
                // Read the data created by the button click handlers and create
                // the command string to send to the service. lock is used here 
                // to make sure that the UI thread cannot change these values 
                // while this worker thread is reading them.
                lock (this)
                {
                    switch (cmd)
                    {
                        case Command.Start:
                            strCmd = String.Format("START {0} {1}", id, watchFolder);
                            break;
                        case Command.Stop:
                            strCmd = String.Format("FINISH {0}", id);
                            break;
                        case Command.Reset:
                            strCmd = String.Format("RESET {0}", id);
                            break;
                        case Command.Results:
                            strCmd = String.Format("RESULTS {0}", id);
                            break;
                    }
                }

                // Got the command, so tell the server.
                IList<KeyValuePair<string, string>> results = client.Send(strCmd);

                // Add the results to the list view control.
                foreach (KeyValuePair<string, string> de in results)
                {
                    // Update the user interface on the user interface thread
                    ctx.Post(new SendOrPostCallback(UpdateListView), de);
                }
            }
            // Cleanup the client socket.
            client.Disconnect();

            // Indicate that this thread has finished
            mreDead.Set();
        }

        // This is called on the user interface thread
        private void UpdateListView(object obj)
        {
            KeyValuePair<string, string> pair = (KeyValuePair<string, string>)obj;
            lvData.Items.Add(new ListViewItem(new string[] { pair.Key, pair.Value}));
        }

        // This is called on the user interface thread
        private void UpdateListView(string str)
        {
            lvData.Items.Add(new ListViewItem(new string[] { DateTime.Now.ToLongTimeString(), str }));
        }

        // This is called to tell the service to watch another folder on behalf 
        // of this client.
        private void btnStart_Click(object sender, EventArgs e)
        {
            // Get the user to search for the folder.
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (watchFolder != null)
            {
                dlg.SelectedPath = watchFolder;
            }
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                UpdateListView("Start work");
                lock (this)
                {
                    watchFolder = dlg.SelectedPath;
                    cmd = Command.Start;
                }
                // Tell the waiting thread to wake up
                areNewData.Set();
            }
        }

        // This is called to tell the service to stop watching folders for this client.
        private void btnStop_Click(object sender, EventArgs e)
        {
            UpdateListView("Finish work");
            lock (this)
            {
                cmd = Command.Stop;
            }
            // Tell the waiting thread to wake up
            areNewData.Set();
        }

        // This is called to tell the service to return results for this client.
        private void btnResults_Click(object sender, EventArgs e)
        {
            UpdateListView("Get data");
            lock (this)
            {
                cmd = Command.Results;
            }
            // Tell the waiting thread to wake up
            areNewData.Set();
        }

        // This is called to clear the resuilts for this client.
        private void btnReset_Click(object sender, EventArgs e)
        {
            UpdateListView("Reset results");
            lock (this)
            {
                cmd = Command.Reset;
            }
            // Tell the waiting thread to wake up
            areNewData.Set();
        }

        // Clean up when the form has closed.
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Kill the listening thread
            bStayAlive = false;
            // If it is asleep, tell the worker thread to wake up
            areNewData.Set();
            // Wait for the worker thread to die
            mreDead.WaitOne();
            // Clean up the client.
            client.Dispose();
        }
    }
}