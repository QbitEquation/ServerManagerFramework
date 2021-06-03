namespace ServerManagerFramework
{
    /// <summary>
    /// Newable version of ServerManagerFramework.IHasString
    /// </summary>
    public struct NewableString : IHasString
    {
        /// <summary>
        /// The string that contains the console line data.
        /// </summary>
        public string String { get; init; }
    }
}
