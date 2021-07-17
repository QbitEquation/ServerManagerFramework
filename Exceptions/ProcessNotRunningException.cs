using System;

namespace ServerManagerFramework.Exceptions
{
    /// <summary>
    /// The exception that is thrown when a process is not running even though it should be.
    /// </summary>
    public class ProcessNotRunningException : Exception
    {
        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
        public ProcessNotRunningException() : base("The Process is not running") { }
    }
}
