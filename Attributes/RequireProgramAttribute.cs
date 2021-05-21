using System;

namespace ServerManagerFramework
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    internal class RequireProgramAttribute : Attribute
    {
        public string ProgramName { get; }
#pragma warning disable IDE0052 // Remove unread private members
        private Version MinVersion { get; }
#pragma warning restore IDE0052 // Remove unread private members
#pragma warning disable IDE0052 // Remove unread private members
        private Version MaxVersion { get; }
#pragma warning restore IDE0052 // Remove unread private members
        public RequireProgramAttribute(string programName)
        {
            ProgramName = programName;
        }

        public RequireProgramAttribute(string programName, Version minVersion)
        {
            ProgramName = programName;
            MinVersion = minVersion;
        }
        public RequireProgramAttribute(string programName, Version minVersion, Version maxVersion)
        {
            ProgramName = programName;
            MinVersion = minVersion;
            MaxVersion = maxVersion;
        }
    }
}
