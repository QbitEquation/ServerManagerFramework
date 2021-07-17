using System;
using System.Windows;

namespace ServerManagerFramework.Installing
{
    /// <summary>
    /// Contains the data that is needed to install a server.
    /// </summary>
    public record Installable(UIElement[] Elements, Type ServerType, InstallAction InstallAction);
}
