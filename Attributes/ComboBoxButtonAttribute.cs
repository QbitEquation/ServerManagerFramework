using System;

namespace ServerManagerFramework
{
    /// <summary>
    /// Enables filtering for a class that inherits from ServerManagerFramework.IHasDirectory.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ComboBoxButtonAttribute : Attribute
    {
        /// <summary>
        /// The name of the ComboBox item that should be displayed.
        /// Null if the default class name should be used.
        /// </summary>
        public string ClassName { get; }

        /// <summary>
        /// Use default class name as ComboBox item name.
        /// </summary>
        public ComboBoxButtonAttribute() { }

        /// <summary>
        /// Use a custom name for the ComboBox item.
        /// </summary>
        /// <param name="name">The name of the ComboBox item that should be displayed.</param>
        public ComboBoxButtonAttribute(string name)
        {
            ClassName = name;
        }
    }
}
