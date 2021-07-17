using System.Collections.Generic;

namespace ServerManagerFramework.ServerInfo
{
    /// <summary>
    /// Indicates that a server has custom ServerInfo items.
    /// </summary>
    public interface IHasServerInfoItems
    {
        /// <summary>
        /// Initializes all Items. 
        /// </summary>
        public IEnumerable<ServerInfoItem> InitializeItems();
    }
}
