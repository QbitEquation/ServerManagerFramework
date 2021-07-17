namespace ServerManagerFramework.Servers
{
    /// <summary>
    /// Base class for all servers that can be started or stopped.
    /// </summary>
    public interface IServer : IHasDirectory
    {
        /// <summary>
        /// Start this server.
        /// </summary>
        public void Start();

        /// <summary>
        /// Stop this server.
        /// </summary>
        public void Stop();

        /// <summary>
        /// Destroy this server process immediately.
        /// </summary>
        public void DestroyProcess();

        /// <summary>
        /// Destroy this server process immediately.
        /// </summary>
        public State State { get; }

        /// <summary>
        /// Fires when the ServerManagerFramework.State of this server changes.
        /// </summary>
        public event StateChangedEventHandler StateChanged;
    }
}
