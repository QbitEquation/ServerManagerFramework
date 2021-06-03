namespace ServerManagerFramework
{
    /// <summary>
    /// Enables UI implemenatation of inputting console text to a server.
    /// </summary>
    public interface ICommandLineInput
    {
        /// <summary>
        /// Writes a line of text to a server process.
        /// </summary>
        /// <param name="value">The string to write.</param>
        public void WriteLine(string value);
    }
}
