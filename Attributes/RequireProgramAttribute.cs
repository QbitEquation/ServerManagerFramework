using System;

namespace ServerManagerFramework
{
    /// <summary>
    /// Indicated that a server requires certain applications installed in order to run.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public class RequireApplicationAttribute : Attribute
    {
        /// <summary>
        /// The name of the application that is required.
        /// </summary>
        public string ApplicationName { get; }

        /// <summary>
        /// The minimum version that should be installed.
        /// </summary>
        public Version MinVersion { get; }

        /// <summary>
        /// The Maximum version that can be installed.
        /// </summary>
        public Version MaxVersion { get; }

        /// <summary>
        /// The direct download URL of the application.
        /// </summary>
        public string DownloadURL { get; }

        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
        /// <param name="programName">The name of the required application.</param>
        public RequireApplicationAttribute(string programName)
        {
            ApplicationName = programName;
        }

        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
        /// <param name="programName">The name of the required application.</param>
        /// <param name="downloadURL">The direct download URL of the required application. This should directly download the installer. The installer should be silently executeable if possible.</param>
        public RequireApplicationAttribute(string programName, string downloadURL)
        {
            ApplicationName = programName;
            DownloadURL = downloadURL; 
        }

        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
        /// <param name="programName">The name of the required application.</param>
        /// <param name="minVersion">The minimum version of the required application.</param>
        public RequireApplicationAttribute(string programName, Version minVersion)
        {
            ApplicationName = programName;
            MinVersion = minVersion;
        }

        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
        /// <param name="programName">The name of the required application.</param>
        /// <param name="minVersion">The minimum version of the required application.</param>
        /// <param name="downloadURL">The direct download URL of the required application. This should directly download the installer. The installer should be silently executeable if possible.</param>
        public RequireApplicationAttribute(string programName, Version minVersion, string downloadURL)
        {
            ApplicationName = programName;
            MinVersion = minVersion;
            DownloadURL = downloadURL;
        }

        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
        /// <param name="programName">The name of the required application.</param>
        /// <param name="minVersion">The minimum version of the required application.</param>
        /// <param name="maxVersion">The maximum version of the required application.</param>
        public RequireApplicationAttribute(string programName, Version minVersion, Version maxVersion)
        {
            ApplicationName = programName;
            MinVersion = minVersion;
            MaxVersion = maxVersion;
        }

        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
        /// <param name="programName">The name of the required application.</param>
        /// <param name="minVersion">The minimum version of the required application.</param>
        /// <param name="maxVersion">The maximum version of the required application.</param>
        /// <param name="downloadURL">The direct download URL of the required application. This should directly download the installer. The installer should be silently executeable if possible.</param>
        public RequireApplicationAttribute(string programName, Version minVersion, Version maxVersion, string downloadURL)
        {
            ApplicationName = programName;
            MinVersion = minVersion;
            MaxVersion = maxVersion;
            DownloadURL = downloadURL;
        }
    }
}
