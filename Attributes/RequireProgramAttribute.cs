using System;

namespace ServerManagerFramework
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class RequireProgramAttribute : Attribute
    {
        public string ProgramName { get; }
        public Version MinVersion { get; }
        public Version MaxVersion { get; }

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
