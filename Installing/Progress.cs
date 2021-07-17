namespace ServerManagerFramework.Installing
{
    /// <summary>
    /// Visual progress change.
    /// </summary>
    public struct Progress
    {
        /// <summary>
        /// The text that should be displayed. Null if the text should stay the same.
        /// </summary>
        public string Text { get; init; }
        /// <summary>
        /// The percentage that should be displayed. -1 if no progress bar should be displayed.
        /// </summary>
        public double Percentage { get; init; }
    }
}
