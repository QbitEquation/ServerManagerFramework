using System.Collections.Generic;
using System.Text;

namespace ServerManagerFramework
{
    /// <summary>
    /// Start arguments helper class for starting servers.
    /// </summary>
    public class Arguments
    {
        private List<string> LeftArguments { get; } = new();
        private List<string> CenterArguments { get; } = new();
        private List<string> RightArguments { get; } = new();

        /// <summary>
        /// Add an argument.
        /// </summary>
        /// <param name="argument">The argument to add.</param>
        /// <param name="argumentPosition">The position of the argument.</param>
        public void Add(string argument, ArgumentPosition argumentPosition)
        {
            if (LeftArguments.Contains(argument)
                || CenterArguments.Contains(argument)
                || RightArguments.Contains(argument))
            {
                return;
            }

            switch (argumentPosition)
            {
                case ArgumentPosition.left:
                    LeftArguments.Add(argument);
                    break;
                case ArgumentPosition.center:
                    CenterArguments.Add(argument);
                    break;
                case ArgumentPosition.right:
                    RightArguments.Add(argument);
                    break;
            }
        }

        /// <summary>
        /// Insert an argument at a certain position.
        /// </summary>
        /// <param name="index">The position where the argument should be inserted.</param>
        /// <param name="argument">The argument to insert.</param>
        /// <param name="argumentPosition">The argument block position.</param>
        public void Insert(int index, string argument, ArgumentPosition argumentPosition)
        {
            if (LeftArguments.Contains(argument)
                || CenterArguments.Contains(argument)
                || RightArguments.Contains(argument))
            {
                return;
            }

            switch (argumentPosition)
            {
                case ArgumentPosition.left:
                    LeftArguments.Insert(index, argument);
                    break;
                case ArgumentPosition.center:
                    CenterArguments.Insert(index, argument);
                    break;
                case ArgumentPosition.right:
                    RightArguments.Insert(index, argument);
                    break;
            }
        }

        /// <summary>
        /// Removes an argument.
        /// </summary>
        /// <param name="arg">The argument to remove.</param>
        public void Remove(string arg)
        {
            LeftArguments.Remove(arg);
            CenterArguments.Remove(arg);
            RightArguments.Remove(arg);
        }

        /// <summary>
        /// Convert this class to a string to add to process start args.
        /// </summary>
        /// <returns>This class converted to a string.</returns>
        public override string ToString()
        {
            StringBuilder startArguments = new();

            foreach (string argument in LeftArguments)
            {
                startArguments.Append(argument);
                startArguments.Append(' ');
            }
            foreach (string argument in CenterArguments)
            {
                startArguments.Append(argument);
                startArguments.Append(' ');
            }
            foreach (string argument in RightArguments)
            {
                startArguments.Append(argument);
                startArguments.Append(' ');
            }

            return startArguments.ToString();
        }
    }
}
