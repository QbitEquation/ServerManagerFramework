using ServerManagerFramework.ServerInfo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;

namespace ServerManagerFramework.Servers
{
    /// <summary>
    /// A server that saves the terminal content as log file. Only use this if the server you are adding doesn't save log files by default.
    /// </summary>
    public class LoggedServer : Server, IHasLog
    {
        #region Overrides
        /// <summary>
        /// Start this server.
        /// </summary>
        public override void Start()
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

            currentSession++;

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
        /// Clears all terminal lines asynchronously.
        /// </summary>
        public override void ClearLines()
        {
            TerminalLine[] terminalLinesCopy = new TerminalLine[terminalLines.Count];
            terminalLines.CopyTo(terminalLinesCopy, 0);
            Application.Current.Dispatcher.Invoke(terminalLines.Clear);

            _ = AppendLog(terminalLinesCopy);
        }
        #endregion

        #region Log
        /// <summary>
        /// The current session of the server.
        /// </summary>
        protected int currentSession = 0;
        /// <summary>
        /// The current session of the log saver.
        /// </summary>
        protected int saveSession = 0;

        /// <summary>
        /// The path to the log folder. From ServerFolder/[your_folder]
        /// </summary>
        public virtual string LogFolder => "logs";

        /// <summary>
        /// Appends text to the current server log.
        /// </summary>
        ///  <param name="contents">The text to append.</param>
        /// <returns></returns>
        public virtual async Task AppendLog(IEnumerable<TerminalLine> contents)
        {
            string logFolderPath = Path.Combine(Directory, LogFolder);
            DirectoryInfo logFolder = System.IO.Directory.CreateDirectory(logFolderPath);

            string latestFileName = Path.Combine(logFolderPath, "latest.log");
            FileInfo latestFile = new(latestFileName);

            if (currentSession == 0)
            {
                return;
            }

            if (currentSession != saveSession)
            {
                saveSession = currentSession;

                await CompressLatest();
                await File.WriteAllTextAsync(latestFileName, string.Empty);
            }

            await File.AppendAllLinesAsync(latestFileName, contents.Select(x => x.ToString()));
        }

        /// <summary>
        /// Compresses the latest log file to a .gz file asynchronously.
        /// </summary>
        /// <returns></returns>
        protected virtual async Task CompressLatest()
        {
            string logFolderPath = Path.Combine(Directory, LogFolder);
            string filePath = Path.Combine(logFolderPath, "latest.log");

            if (!File.Exists(filePath))
            {
                return;
            }

            //Generate new file Name
            string fN = logFolderPath;
            fN += '\\';
            //Time string could change depending on system language
            string currentDay = DateTime.Today.ToString("yyyy-MM-dd");
            fN += currentDay.Replace('.', '-');
            fN += "-";

            int iteration = 1;
            string fileName = fN + iteration + ".log.gz";

            while (File.Exists(fileName))
            {
                iteration++;
                fileName = fN + iteration + ".log.gz";
            }

            FileStream compressedLog = File.Create(fileName);
            FileStream latestLog = new(filePath, FileMode.Open);
            GZipStream compression = new(compressedLog, CompressionMode.Compress);

            await latestLog.CopyToAsync(compression);

            await compression.DisposeAsync();
            await compressedLog.DisposeAsync();
            await latestLog.DisposeAsync();
        }
        #endregion
    }
}