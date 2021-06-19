using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Timers;
using System.Windows;

namespace ServerManagerFramework
{
    /// <summary>
    /// Base class for server processes that includes input and output handling.
    /// </summary>
    public class ServerProcess : IServer, ICommandLineInput, ICommandLineOutput
    {
        /// <summary>
        /// Initializes a new Instance of this class.
        /// </summary>
        public ServerProcess()
        {
            StartInfo.RedirectStandardInput = true;
            StartInfo.RedirectStandardOutput = true;
            StartInfo.UseShellExecute = false;

            Application.Current.Exit += OnExit;
        }

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
        /// Is called when everything is initialized.
        /// </summary>
        #pragma warning disable 0067
        public event EventHandler Initialized;

        /// <summary>
        /// The System.Diagnostics.Process of this server.
        /// </summary>
        protected Process Process { get; set; }

        /// <summary>
        /// The System.Diagnostics.ProcessStartInfo of this System.Diagnostics.Process.
        /// </summary>
        protected ProcessStartInfo StartInfo { get; } = new ProcessStartInfo();

        private int ProcessID { get; set; } = -1;

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

            /*Process.Start();
            ProcessID = Process.Id;
            State = State.started;

            Process.BeginOutputReadLine();
            Process.OutputDataReceived += OutputDataReceived;

            Timer clearCheck = new(60000);
            clearCheck.Elapsed += delegate
            {
                Application.Current.Dispatcher.Invoke(delegate
                {
                    if (consoleLines.Count > 1000)
                    {
                        consoleLines.Clear();
                    }
                });
            };
            clearCheck.Start();*/
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
        protected readonly ObservableCollection<CommandLine> consoleLines = new();

        /// <summary>
        /// The output lines.
        /// </summary>
        public IEnumerable<CommandLine> ConsoleLines => consoleLines;

        /// <summary>
        /// Catches output data of this process.
        /// </summary>
        /// <param name="sender">The process that generated output.</param>
        /// <param name="e">The process output data.</param>
        protected virtual void OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(delegate
            {
                CommandLine line = new()
                {
                    Message = e.Data,
                    FontColor = SMR.SFontColorBrush,
                };

                consoleLines.Add(line);
            });
        }

        /// <summary>
        /// Adds a line to the console output
        /// </summary>
        public void AddLine(CommandLine line)
        {
            consoleLines.Add(line);
        }
        /// <summary>
        /// Clears all console line entries.
        /// </summary>
        public void ClearLines()
        {
            consoleLines.Clear();
        }
        #endregion
    }
}
