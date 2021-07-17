using ServerManagerFramework.ServerInfo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Timers;
using System.Windows;

namespace ServerManagerFramework.Servers
{
    /// <summary>
    /// Base class for server processes that includes input and output handling.
    /// </summary>
    public class Server : IServer, ITerminalInput, ITerminalOutput
    {
        /// <summary>
        /// Initializes a new Instance of this class.
        /// </summary>
        public Server()
        {
            Application.Current.Exit += OnExit;
        }

        /// <summary>
        /// The configuration for this server.
        /// </summary>
        public Config.Config Config { get; init; }

        /// <summary>
        /// The directory of this server.
        /// </summary>
        public string Directory
        {
            get => StartInfo.WorkingDirectory;
            init => StartInfo.WorkingDirectory = value;
        }

        /// <summary>
        /// Is called when everything is initialized.
        /// </summary>
        public virtual void Initialized() { }

        /// <summary>
        /// True when the server is initialized.
        /// </summary>
        public bool IsInitialized { get; private set; }

        /// <summary>
        /// The System.Diagnostics.Process of this server.
        /// </summary>
        protected Process Process { get; set; }

        /// <summary>
        /// The System.Diagnostics.ProcessStartInfo of this System.Diagnostics.Process.
        /// </summary>
        protected ProcessStartInfo StartInfo { get; } = new()
        {
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        /// <summary>
        /// 
        /// </summary>
        protected int ProcessID { get; set; } = -1;

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

            Process = new Process
            {
                StartInfo = StartInfo,
                EnableRaisingEvents = true
            };
            Process.Exited += Exited;

            Process.Start();
            ProcessID = Process.Id;
            State = State.started;

            Process.BeginOutputReadLine();
            Process.OutputDataReceived += OutputDataReceived;

            Timer clearCheck = new(15000);
            clearCheck.Elapsed += delegate
            {
                Application.Current.Dispatcher.Invoke(delegate
                {
                    if (terminalLines.Count > 1000)
                    {
                        ClearLines();
                    }
                });
            };
            clearCheck.Start();
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
        /// Destroy this server process immediately.
        /// </summary>
        public void DestroyProcess()
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Exited(object sender, EventArgs e)
        {
            DestroyProcess();

            ClearLines();
        }

        /// <summary>
        /// Is called when Server-Manager exits.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnExit(object sender, ExitEventArgs args)
        {
            if (ProcessID == -1)
            {
                return;
            }

            Process[] processlist = Process.GetProcesses();
            Process serverProcess = processlist.FirstOrDefault(p => p.Id == ProcessID);

            serverProcess?.Kill();
        }
        #endregion

        #region Input
        /// <summary>
        /// Write a line to the InputStream.
        /// </summary>
        /// <param name="value">The string to write.</param>
        public virtual void WriteLine(string value)
        {
            if (State != State.started)
            {
                return;
            }

            Process.StandardInput.WriteLine(value);
        }
        #endregion

        #region Output
        /// <summary>
        /// The output lines.
        /// </summary>
        protected readonly ObservableCollection<TerminalLine> terminalLines = new();

        /// <summary>
        /// The output lines.
        /// </summary>
        public IEnumerable<TerminalLine> TerminalLines => terminalLines;

        /// <summary>
        /// Catches output data of this process.
        /// </summary>
        /// <param name="sender">The process that generated output.</param>
        /// <param name="e">The process output data.</param>
        protected virtual void OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Data))
            {
                return;
            }

            Application.Current.Dispatcher.Invoke(delegate
            {
                TerminalLine line = new()
                {
                    Message = e.Data,
                    FontColor = SMR.SFontColorBrush,
                };

                terminalLines.Add(line);
            });
        }

        /// <summary>
        /// Adds a line to the terminal output
        /// </summary>
        public void AddLine(TerminalLine line)
        {
            terminalLines.Add(line);
        }

        /// <summary>
        /// Clears all terminal line entries.
        /// </summary>
        public virtual void ClearLines()
        {
            Application.Current.Dispatcher.Invoke(terminalLines.Clear);
        }
        #endregion
    }
}
