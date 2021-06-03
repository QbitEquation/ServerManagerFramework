namespace ServerManagerFramework
{
    /// <summary>
    /// Base class for all servers that can be started or stopped.
    /// </summary>
    public interface IServer : IHasDirectory
    {
        /// <summary>
        /// Start this server.
        /// </summary>
        void Start();

        /// <summary>
        /// Stop this server.
        /// </summary>
        void Stop();

        /// <summary>
        /// The current ServerManagerFramework.State of this server.
        /// </summary>
        State State { get; }

        /// <summary>
        /// Fires when the ServerManagerFramework.State of this server changes.
        /// </summary>
        event StateChangedEventHandler StateChanged;
    }
}
