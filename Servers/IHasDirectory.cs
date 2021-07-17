namespace ServerManagerFramework.Servers
{
    /// <summary>
    /// Base class for all servers.
    /// </summary>
    public interface IHasDirectory
    {
        /// <summary>
        /// The directory of this server. (Initialized automatically)
        /// </summary>
        public string Directory { get; init; }

        /// <summary>
        /// Is called when everything is initialized.
        /// </summary>
        public void Initialized();

        /// <summary>
        /// The configuration for this server. (Initialized automatically)
        /// </summary>
        public Config.Config Config { get; init; }
    }
}
