namespace ServerManagerFramework.Servers
{
    /// <summary>
    /// The state of a server.
    /// </summary>
    public enum State
    {
        /// <summary>
        /// The server is starting.
        /// </summary>
        starting,

        /// <summary>
        /// The server is running.
        /// </summary>
        started,

        /// <summary>
        /// The server is stopping.
        /// </summary>
        stopping,

        /// <summary>
        /// The server is stopped.
        /// </summary>
        stopped
    }
}
