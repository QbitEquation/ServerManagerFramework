using System;
using System.Diagnostics;
using System.Management;
using System.Windows;

namespace ServerManagerFramework
{
    public class ServerProcess : IServer
    {
        public string Directory { get; }
        protected Process Process { get; set; }
        protected ProcessStartInfo StartInfo { get; } = new ProcessStartInfo();
        int ProcessID { get; set; } = -1;

        public ServerProcess(string workingDirectory, string fileName)
        {
            Directory = workingDirectory;

            StartInfo.UseShellExecute = false;
            StartInfo.WorkingDirectory = Directory;
            StartInfo.FileName = fileName;

            Application.Current.Exit += OnExit;
        }

        #region Arguments
        private readonly Arguments arguments = new();

        protected Arguments Arguments => arguments;

        public void AddArgument(string argument)
        {
            Arguments.Add(argument, ArgumentPosition.center);
        }
        public void InsertArgument(int index, string argument)
        {
            Arguments.Insert(index, argument, ArgumentPosition.center);
        }
        public void RemoveArgument(string argument)
        {
            Arguments.Remove(argument);
        }
        #endregion

        #region Starting / Stopping
        private State state = State.stopped;
        public State State 
        { 
            get
            {
                return state;
            }
            protected set
            {
                if (value == state) return;

                state = value;
                StateChanged?.Invoke(this, new StateChangedEventArgs(state));
            }
        }
        public event StateChangedEventHandler StateChanged;

        public virtual void Start()
        {
            if (State != State.stopped || string.IsNullOrWhiteSpace(StartInfo.FileName))
            {
                return;
            }

            StartInfo.Arguments = Arguments.ToString();

            Process = new Process
            {
                StartInfo = StartInfo,
                EnableRaisingEvents = true
            };
            Process.Exited += Exited;

            Process.Start();
            ProcessID = Process.Id;
            State = State.started;
        }
        public virtual void Stop()
        {
            if (State == State.stopped)
            {
                return;
            }

            DestroyProcess();
        }
        protected void DestroyProcess()
        {
            if (Process.HasExited == false)
            {
                Process.Kill();
            }

            Application.Current.Dispatcher.Invoke(() =>
            {
                State = State.stopped;
            });
            Process.Dispose();
            Process = null;
        }

        private void Exited(object sender, EventArgs e)
        {
            DestroyProcess();
        }
        private void OnExit(object sender, ExitEventArgs args)
        {
            if (ProcessID == -1)
            {
                return;
            }

            Process process = Process.GetProcessById(ProcessID);

            process.Kill();
        }
        #endregion
    }
}
