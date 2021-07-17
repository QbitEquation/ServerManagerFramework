namespace ServerManagerFramework.ServerInfo
{
    /// <summary>
    /// Enables UI implemenatation of inputting text to a server.
    /// </summary>
    public interface ITerminalInput
    {
        /// <summary>
        /// Writes a line of text to a server process.
        /// </summary>
        /// <param name="value">The string to write.</param>
        public void WriteLine(string value);
    }
}
