using System.Windows.Media;

namespace ServerManagerFramework.ServerInfo
{
    /// <summary>
    /// 
    /// </summary>
    public struct TerminalLine
    {
        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public StyleSimulations FontStyle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SolidColorBrush FontColor { get; set; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return Message;
        }
    }
}
