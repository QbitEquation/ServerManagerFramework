using System;

namespace ServerManagerFramework
{
    /// <summary>
    /// Base class for all servers.
    /// </summary>
    public interface IHasDirectory
    {
        /// <summary>
        /// The directory of this server.
        /// </summary>
        string Directory { get; init; }

        /// <summary>
        /// Is called when everything is initialized.
        /// </summary>
        public event EventHandler Initialized;
    }
}
