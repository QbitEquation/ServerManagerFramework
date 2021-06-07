using System;

namespace ServerManagerFramework
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
        public string IconPath { get; }

        /// <summary>
        /// Use default icon name. [server-icon.png]
        /// </summary>
        public HasIconAttribute()
        {
            IconPath = "server-icon.png";
        }

        /// <summary>
        /// Specify a custom icon name.
        /// </summary>
        /// <param name="iconPath">The path and name of the icon file.</param>
        public HasIconAttribute(string iconPath)
        {
            IconPath = iconPath;
        }
    }
}
