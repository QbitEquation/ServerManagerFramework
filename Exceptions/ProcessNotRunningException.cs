using System;

namespace ServerManagerFramework
{
    public class ProcessNotRunningException : Exception
    {
        public ProcessNotRunningException() : base("The Process is not running") { }
    }
}
