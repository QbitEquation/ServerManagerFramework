using System.Collections.Generic;

namespace ServerManagerFramework.Installing
{
    /// <summary>
    /// Encapsulates a method that installes a server.
    /// </summary>
    /// <param name="directory">The directory where the server should be installed.</param>
    public delegate IAsyncEnumerable<Progress> InstallAction(string directory);
}
