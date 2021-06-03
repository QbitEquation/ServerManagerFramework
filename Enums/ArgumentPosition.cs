namespace ServerManagerFramework
{
    /// <summary>
    /// The main block position of an argument.
    /// </summary>
    public enum ArgumentPosition
    {
        /// <summary>
        /// Argument is always one of the first ones to be read.
        /// </summary>
        left,

        /// <summary>
        /// Main block for most arguments.
        /// </summary>
        center,

        /// <summary>
        /// Argument is always one of the last ones to be read.
        /// </summary>
        right
    }
}
