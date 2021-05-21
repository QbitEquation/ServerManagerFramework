using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ServerManagerFramework
{
    public class ServerProcess<T> : ServerProcess, ICommandLineInput, ICommandLineOutput<T> where T : IHasString, new()
    {
        public ServerProcess(string workingDirectory, string fileName) : base(workingDirectory, fileName)
        {
            StartInfo.RedirectStandardInput = true;
            StartInfo.RedirectStandardOutput = true;
        }

        #region Input
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
        protected readonly ObservableCollection<T> consoleLines = new();
        public IEnumerable<T> ConsoleLines => consoleLines;

        protected virtual void OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            T data = new();
            data.SetString(e.Data);

            consoleLines.Add(data);
        }

        public override void Start()
        {
            base.Start();

            Process.BeginOutputReadLine();
            Process.OutputDataReceived += OutputDataReceived;
        }
        #endregion
    }
}
