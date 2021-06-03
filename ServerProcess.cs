using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ServerManagerFramework
{
    /// <summary>
    /// Base class for server processes that includes input and output handling.
    /// </summary>
    /// <typeparam name="TCommandLineObject">The object that should be used to store the command line strings</typeparam>
    public class ServerProcess<TCommandLineObject> : ServerProcess, ICommandLineInput, ICommandLineOutput<TCommandLineObject> where TCommandLineObject : IHasString, new()
    {
        /// <summary>
        /// Initializes a new Instance of this class.
        /// </summary>
        /// <param name="fileName">The name of the file that is used to start the server.</param>
        public ServerProcess(string fileName) : base(fileName)
        {
            StartInfo.RedirectStandardInput = true;
            StartInfo.RedirectStandardOutput = true;
        }

        #region Input
        /// <summary>
        /// Write a line to the InputStream.
        /// </summary>
        /// <param name="value">The string to write.</param>
        public virtual void WriteLine(string value)
        {
            if (State != State.started)
            {
                throw new ProcessNotRunningException();
            }

            Process.StandardInput.WriteLine(value);
        }
        #endregion

        #region Output
        /// <summary>
        /// The output lines.
        /// </summary>
        protected readonly ObservableCollection<TCommandLineObject> consoleLines = new();

        /// <summary>
        /// The output lines.
        /// </summary>
        public IEnumerable<TCommandLineObject> ConsoleLines => consoleLines;

        /// <summary>
        /// Catches output data of this process.
        /// </summary>
        /// <param name="sender">The process that generated output.</param>
        /// <param name="e">The process output data.</param>
        protected virtual void OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            TCommandLineObject data = new()
            {
                String = e.Data
            };

            consoleLines.Add(data);
        }

        /// <summary>
        /// Start this server.
        /// </summary>
        public override void Start()
        {
            base.Start();

            Process.BeginOutputReadLine();
            Process.OutputDataReceived += OutputDataReceived;
        }
        #endregion
    }
}
