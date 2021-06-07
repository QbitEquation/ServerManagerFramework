using System;
using System.Diagnostics;
using System.Windows;

namespace ServerManagerFramework
{
    /// <summary>
    /// Base class for server processes. Not required to run a server.
    /// </summary>
    public class ServerProcess : IServer
    {
        /// <summary>
        /// The directory of this server.
        /// </summary>
        public string Directory
        {
            get => StartInfo.WorkingDirectory;
            init
            {
                StartInfo.WorkingDirectory = value;
            }
        }

        /// <summary>
        /// The System.Diagnostics.Process of this server.
        /// </summary>
        protected Process Process { get; set; }

        /// <summary>
        /// The System.Diagnostics.ProcessStartInfo of this System.Diagnostics.Process.
        /// </summary>
        protected ProcessStartInfo StartInfo { get; } = new ProcessStartInfo();

        private int ProcessID { get; set; } = -1;

        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
        /// <param name="fileName">The name of the file that is used to start this server.</param>
        public ServerProcess(string fileName)
        {
            StartInfo.UseShellExecute = false;
            StartInfo.FileName = fileName;

            Application.Current.Exit += OnExit;
        }

        #region Arguments
        private readonly Arguments arguments = new();

        /// <summary>
        /// The start ServerManagerFramework.Arguments of this server.
        /// </summary>
        protected Arguments Arguments => arguments;

        /// <summary>
        /// Add an argument.
        /// </summary>
        /// <param name="argument">The argument to add.</param>
        public void AddArgument(string argument)
        {
            Arguments.Add(argument, ArgumentPosition.center);
        }

        /// <summary>
        /// Insert an argument at a certain position.
        /// </summary>
        /// <param name="index">The position of this argument.</param>
        /// <param name="argument">The argument to insert.</param>
        public void InsertArgument(int index, string argument)
        {
            Arguments.Insert(index, argument, ArgumentPosition.center);
        }

        /// <summary>
        /// Remove an argument.
        /// </summary>
        /// <param name="argument">The argument to remove.</param>
        public void RemoveArgument(string argument)
        {
            Arguments.Remove(argument);
        }
        #endregion

        #region Starting / Stopping
        private State state = State.stopped;

        /// <summary>
        /// The current ServerManagerFramework.State of this server.
        /// </summary>
        public State State
        {
            get => state;
            protected set
            {
                if (value == state)
                {
                    return;
                }

                state = value;
                StateChanged?.Invoke(this, new StateChangedEventArgs(state));
            }
        }

        /// <summary>
        /// Fires when the ServerManagerFramework.State of this server changes.
        /// </summary>
        public event StateChangedEventHandler StateChanged;

        /// <summary>
        /// Start this server.
        /// </summary>
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

        /// <summary>
        /// Stop this server.
        /// </summary>
        public virtual void Stop()
        {
            if (State == State.stopped)
            {
                return;
            }

            DestroyProcess();
        }

        /// <summary>
        /// Destroy this server process.
        /// </summary>
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
