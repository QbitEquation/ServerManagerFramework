namespace ServerManagerFramework
{
    /// <summary>
    /// Indicates that a server can be installed.
    /// </summary>
    public interface IInstallable
    {
        /// <summary>
        /// Installes this server.
        /// </summary>
        void Install();
    }
}
