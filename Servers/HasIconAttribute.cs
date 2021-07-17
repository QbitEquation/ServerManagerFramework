using System;

namespace ServerManagerFramework.Servers
{

    /// <summary>
    /// Indicates that a class has an icon that should be displayed in serverInfo.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class HasIconAttribute : Attribute
    {
        /// <summary>
        /// The path of the icon file of a server. From ServerFileName/[iconName.fileExtension]
        /// </summary>
        public string IconPath { get; set; } = "server-icon.png";

        /// <summary>
        /// The file extensions that are allowed.
        /// </summary>
        public string Filter { get; set; } = "All files (*.*)|*.*";

        /// <summary>
        /// The tooltip that is shown when hovering over the icon button
        /// </summary>
        public string ToolTip { get; set; }

        /// <summary>
        /// Use default icon name. [server-icon.png]
        /// </summary>
        public HasIconAttribute() { }
    }
}
