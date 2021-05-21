using System.Collections.Generic;

namespace ServerManagerFramework
{
    public interface ICommandLineOutput<T> where T : IHasString
    {
        public IEnumerable<T> ConsoleLines { get; }
    }
}
