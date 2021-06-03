namespace ServerManagerFramework
{
    /// <summary>
    /// The base object for console line entries.
    /// </summary>
    public interface IHasString
    {
        /// <summary>
        /// The string that contains the console line data.
        /// </summary>
        public string String { get; init; }
    }
}
