using System;

namespace ServerManagerFramework
{
    /// <summary>
    /// Indicated that a server requires certain program installed in order to run.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public class RequireProgramAttribute : Attribute
    {
        /// <summary>
        /// The name of the program that is required.
        /// </summary>
        public string ProgramName { get; }

        /// <summary>
        /// The minimum version that should be installed.
        /// </summary>
        public Version MinVersion { get; }

        /// <summary>
        /// The Maximum version that can be installed.
        /// </summary>
        public Version MaxVersion { get; }

        /// <summary>
        /// The direct download URL of the program.
        /// </summary>
        public string DownloadURL { get; }

        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
        /// <param name="programName">The name of the required program.</param>
        public RequireProgramAttribute(string programName)
        {
            ProgramName = programName;
        }

        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
        /// <param name="programName">The name of the required program.</param>
        /// <param name="downloadURL">The direct download URL of the required program. This should directly download the installer. The installer should be silently executeable if possible.</param>
        public RequireProgramAttribute(string programName, string downloadURL)
        {
            ProgramName = programName;
            DownloadURL = downloadURL; 
        }

        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
        /// <param name="programName">The name of the required program.</param>
        /// <param name="minVersion">The minimum version of the required program.</param>
        public RequireProgramAttribute(string programName, Version minVersion)
        {
            ProgramName = programName;
            MinVersion = minVersion;
        }

        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
        /// <param name="programName">The name of the required program.</param>
        /// <param name="minVersion">The minimum version of the required program.</param>
        /// <param name="downloadURL">The direct download URL of the required program. This should directly download the installer. The installer should be silently executeable if possible.</param>
        public RequireProgramAttribute(string programName, Version minVersion, string downloadURL)
        {
            ProgramName = programName;
            MinVersion = minVersion;
            DownloadURL = downloadURL;
        }

        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
        /// <param name="programName">The name of the required program.</param>
        /// <param name="minVersion">The minimum version of the required program.</param>
        /// <param name="maxVersion">The maximum version of the required program.</param>
        public RequireProgramAttribute(string programName, Version minVersion, Version maxVersion)
        {
            ProgramName = programName;
            MinVersion = minVersion;
            MaxVersion = maxVersion;
        }

        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
        /// <param name="programName">The name of the required program.</param>
        /// <param name="minVersion">The minimum version of the required program.</param>
        /// <param name="maxVersion">The maximum version of the required program.</param>
        /// <param name="downloadURL">The direct download URL of the required program. This should directly download the installer. The installer should be silently executeable if possible.</param>
        public RequireProgramAttribute(string programName, Version minVersion, Version maxVersion, string downloadURL)
        {
            ProgramName = programName;
            MinVersion = minVersion;
            MaxVersion = maxVersion;
            DownloadURL = downloadURL;
        }
    }
}
