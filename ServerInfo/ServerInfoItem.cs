using System.Windows;

namespace ServerManagerFramework.ServerInfo
{
    /// <summary>
    /// Defines an item that is displayed in ServerInfo.
    /// </summary>
    public record ServerInfoItem(string Name, UIElement Element);
}
