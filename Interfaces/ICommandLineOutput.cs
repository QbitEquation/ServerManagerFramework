using System.Collections.Generic;

namespace ServerManagerFramework
{
    /// <summary>
    /// Enables UI implemenatation of getting console output from a server.
    /// </summary>
    public interface ICommandLineOutput
    {
        /// <summary>
        /// Gets all console lines of a server.
        /// </summary>
        public IEnumerable<CommandLine> ConsoleLines { get; }
        /// <summary>
        /// Adds a line to the console output
        /// </summary>
        public void AddLine(CommandLine line);
        /// <summary>
        /// Clears all console line entries.
        /// </summary>
        public void ClearLines();
    }
}
