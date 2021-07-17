using System;

namespace ServerManagerFramework.ServerInfo
{
    /// <summary>
    /// A ServerInfo item that can be saved.
    /// </summary>
    public interface ISavableServerInfoItem
    {
        /// <summary>
        /// Indicates if this item can be saved.
        /// </summary>
        public bool CanSave { get; set; }

        /// <summary>
        /// Do not set or change.
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Occurs when this item can be saved.
        /// </summary>
        public event CanSaveChangedEventHandler CanSaveChanged;

        /// <summary>
        /// Saves this item.
        /// </summary>
        public void Save();
    }
}
