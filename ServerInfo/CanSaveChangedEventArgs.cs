using System;

namespace ServerManagerFramework.ServerInfo
{
    /// <summary>
    /// EventArgs that contain the new server savability state.
    /// </summary>
    public class CanSaveChangedEventArgs : EventArgs
    {
        /// <summary>
        /// The new server savability state.
        /// </summary>
        public bool CanSave { get; }

        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
        /// <param name="canSave">The new server savability state.</param>
        public CanSaveChangedEventArgs(bool canSave)
        {
            CanSave = canSave;
        }
    }
}
