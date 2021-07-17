using System;

namespace ServerManagerFramework.Servers
{
    /// <summary>
    /// EventArgs that contain the new ServerManagerFramework.State of a server.
    /// </summary>
    public class StateChangedEventArgs : EventArgs
    {
        /// <summary>
        /// The new server ServerManagerFramework.State.
        /// </summary>
        public State ServerState { get; }

        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
        /// <param name="serverState">The new ServerManagerFramework.State of a server.</param>
        public StateChangedEventArgs(State serverState)
        {
            ServerState = serverState;
        }
    }
}
