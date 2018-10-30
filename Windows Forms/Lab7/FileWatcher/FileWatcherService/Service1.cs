using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Collections;
using System.IO;
using IPC;

namespace FileWatcherService
{
    public partial class Service1 : ServiceBase
    {
        private ServerSide server;
        Dictionary<int, List<string>> data;
        Dictionary<string, IndexedWatcher> watchers;

        class IndexedWatcher : FileSystemWatcher
        {
            public List<int> ProcessesWatching;

            public IndexedWatcher(string folder, string filter, FileSystemEventHandler handler)
                : base(folder, filter)
            {
                ProcessesWatching = new List<int>();
                this.Created += handler;
                this.Changed += handler;
                this.Deleted += handler;
            }

            public void AddProcess(int id)
            {
                lock (ProcessesWatching)
                {
                    if (!ProcessesWatching.Contains(id))
                    {
                        ProcessesWatching.Add(id);
                        EnableRaisingEvents = true;
                    }
                }
            }

            public void RemoveProcess(int id)
            {
                lock (ProcessesWatching)
                {
                    ProcessesWatching.Remove(id);
                    if (ProcessesWatching.Count == 0)
                    {
                        EnableRaisingEvents = false;
                    }
                }
            }
        }

        public Service1()
        {
            InitializeComponent();
            server = new ServerSide(5000);
            data = new Dictionary<int, List<string>>();
            watchers = new Dictionary<string, IndexedWatcher>();
            server.ReceivedCommand += new ReceivedCommandDelegate(server_ReceivedCommand);
        }

        void server_ReceivedCommand(string command, System.Collections.Generic.IList<KeyValuePair<string, string>> results)
        {
            if (command.Length == 0)
            {
                Report(results, "No command");
                return;
            }
            string[] cmdParams = command.Split(new char[] { ' ' });
            if (cmdParams.Length < 2)
            {
                Report(results, "Not enough parameters");
                return;
            }
            int id = Int32.Parse(cmdParams[1]);
            switch (cmdParams[0])
            {
            case "RESET":
                OnReset(id, results);
                break;
            case "START":
                if (cmdParams.Length < 3)
                {
                    Report(results, "Not enough parameters");
                    return;
                }
                OnStart(id, cmdParams[2], results);
                break;
            case "FINISH":
                OnFinish(id, results);
                break;
            case "RESULTS":
                OnResults(id, results);
                break;
            default:
                Report(results, "Unrecognised command");
                break;
            }
        }

        private void OnResults(int id, IList<KeyValuePair<string, string>> results)
        {
            Report(results, "Called OnResults");
            lock (data)
            {
                List<string> items;
                if (data.TryGetValue(id, out items))
                {
                    foreach (string str in items)
                    {
                        Report(results, str);
                    }
                }
                else
                {
                    Report(results, "No data for this client");
                }
            }
            OnReset(id, results);
        }

        private void OnReset(int id, IList<KeyValuePair<string, string>> results)
        {
            Report(results, "Called OnReset");
            lock (data)
            {
                List<string> items;
                if (data.TryGetValue(id, out items))
                {
                    items.Clear();
                }
            }
        }

        private void OnStart(int id, string folder, IList<KeyValuePair<string, string>> results)
        {
            Report(results, String.Format("Called OnStart to watch {0}", folder));
            lock (data)
            {
                if (!data.ContainsKey(id))
                {
                    data.Add(id, new List<String>());
                }
            }

            lock (watchers)
            {
                if (watchers.ContainsKey(folder))
                {
                    watchers[folder].AddProcess(id);
                }
                else
                {
                    IndexedWatcher newWatcher = new IndexedWatcher(folder, "*.*", new FileSystemEventHandler(FileEventHandler));
                    watchers.Add(folder, newWatcher);
                    newWatcher.AddProcess(id);
                }
            }
        }

        private void OnFinish(int id, IList<KeyValuePair<string, string>> results)
        {
            Report(results, "Called OnFinish");
            OnResults(id, results);
            lock (data)
            {
                data.Remove(id);
            }

            lock (watchers)
            {
                foreach (KeyValuePair<string, IndexedWatcher> pair in watchers)
                {
                    pair.Value.RemoveProcess(id);
                }
            }
        }

        private void Report(IList<KeyValuePair<string, string>> results, string str)
        {
            results.Add(new KeyValuePair<string, string>(DateTime.Now.ToLongTimeString(), str));
        }

        private void FileEventHandler(Object sender, FileSystemEventArgs e)
        {
            IndexedWatcher watcher = sender as IndexedWatcher;
            string str = String.Format("{0} {1}", e.FullPath, e.ChangeType);
            lock (watcher.ProcessesWatching)
            lock (data)
            {
                foreach (int id in watcher.ProcessesWatching)
                {
                    data[id].Add(str);
                }
            }
        }

        protected override void OnStart(string[] args)
        {
            server.Listen();
        }

        protected override void OnStop()
        {
            server.StopListening();
        }
    }
}
