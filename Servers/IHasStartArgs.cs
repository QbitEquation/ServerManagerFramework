namespace ServerManagerFramework.Servers
{
    /// <summary>
    /// Indicates that a start args text field should be displayed in ServerInfo.
    /// </summary>
    public interface IHasStartArgs
    {
        /// <summary>
        /// The arguments used to start the server.
        /// </summary>
        public string Arguments { get; set; }
    }
}
