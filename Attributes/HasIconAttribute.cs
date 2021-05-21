using System;

namespace ServerManagerFramework
{
    [AttributeUsage(AttributeTargets.Class)]
    public class HasIconAttribute : Attribute
    {
        public readonly string iconPath = "server-icon.png";
        public HasIconAttribute() { }
        public HasIconAttribute(string iconPath)
        {
            this.iconPath = iconPath;
        }
    }
}
