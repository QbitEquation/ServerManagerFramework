using System;

namespace ServerManagerFramework.Addons
{
    /// <summary>
    /// Indicated that an addon requires something installed in order to run.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class RequireAttribute : Attribute
    {
        /// <summary>
        /// The name of the item that is required.
        /// </summary>
        public string ItemName { get; }
        /// <summary>
        /// The type of the item that is required.
        /// </summary>
        public ItemType ItemType { get; }

        /// <summary>
        /// The minimum version that should be installed. (MajorREQUIRED.MinorREQUIRED.Build.Revision)
        /// </summary>
        public string MinVersion { get; set; }

        /// <summary>
        /// The Maximum version that can be installed. (MajorREQUIRED.MinorREQUIRED.Build.Revision)
        /// </summary>
        public string MaxVersion { get; set; }

        /// <summary>
        /// The direct download URL of the item.
        /// </summary>
        public string DownloadURL { get; set; }

        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
        /// <param name="itemName">The name of the required item.</param>
        /// <param name="itemType">The type of the required item.</param>

        public RequireAttribute(string itemName, ItemType itemType)
        {
            ItemName = itemName;
            ItemType = itemType;
        }
    }
}
