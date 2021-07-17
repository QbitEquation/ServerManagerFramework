namespace ServerManagerFramework.ServerInfo
{
    /// <summary>
    /// Indicates that a server has logs.
    /// </summary>
    public interface IHasLog
    {
        /// <summary>
        /// The path to the log folder. From ServerFolder/[your_folder]
        /// </summary>
        public string LogFolder { get; }
    }
}
