using System.Collections.Generic;

namespace ServerManagerFramework
{
    /// <summary>
    /// Enables UI implemenatation of getting console output from a server.
    /// </summary>
    /// <typeparam name="TCommandLineObject">The object that should be used to store the command line strings</typeparam>
    public interface ICommandLineOutput<TCommandLineObject> where TCommandLineObject : IHasString
    {
        /// <summary>
        /// Gets all console lines of a server.
        /// </summary>
        public IEnumerable<TCommandLineObject> ConsoleLines { get; }
    }
}
