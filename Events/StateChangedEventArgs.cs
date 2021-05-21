using System;

namespace ServerManagerFramework
{
    public class StateChangedEventArgs : EventArgs
    {
        public State serverState;

        public StateChangedEventArgs(State serverState)
        {
            this.serverState = serverState;
        }
    }
}
