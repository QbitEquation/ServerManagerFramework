using System;

namespace ServerManagerFramework.Exceptions
{
    /// <summary>
    /// The exception that is thrown when a process is running even though it should not be.
    /// </summary>
    public class ProcessRunningException : Exception
    {
        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
        public ProcessRunningException() : base("The Process is already running") { }
    }
}
