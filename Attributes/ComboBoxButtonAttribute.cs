using System;

namespace ServerManagerFramework
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ComboBoxButtonAttribute : Attribute
    {
        public readonly string className;
        public readonly bool useDefault = false;

        public ComboBoxButtonAttribute()
        {
            useDefault = true;
        }

        public ComboBoxButtonAttribute(string name)
        {
            className = name;
        }
    }
}
