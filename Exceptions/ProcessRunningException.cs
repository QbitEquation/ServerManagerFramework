using System;

namespace ServerManagerFramework
{
    public class ProcessRunningException : Exception
    {
        public ProcessRunningException() : base("The Process is already running") { }
    }
}
