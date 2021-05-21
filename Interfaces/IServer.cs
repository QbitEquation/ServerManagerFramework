namespace ServerManagerFramework
{
    public interface IServer : IHasDirectory
    {
        void Start();
        void Stop();
        State State { get; }
        event StateChangedEventHandler StateChanged;
    }
}
