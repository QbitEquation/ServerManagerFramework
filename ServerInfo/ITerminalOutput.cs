using System.Collections.Generic;

namespace ServerManagerFramework.ServerInfo
{
    /// <summary>
    /// Enables UI implemenatation of getting terminal output from a server.
    /// </summary>
    public interface ITerminalOutput
    {
        /// <summary>
        /// Gets all terminal lines of a server.
        /// </summary>
        public IEnumerable<TerminalLine> TerminalLines { get; }
        /// <summary>
        /// Adds a line to the terminal output
        /// </summary>
        public void AddLine(TerminalLine line);
        /// <summary>
        /// Clears all terminal line entries.
        /// </summary>
        public void ClearLines();
    }
}
