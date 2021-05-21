using System.Collections.Generic;
using System.Text;

namespace ServerManagerFramework
{
    public class Arguments
    {
        private List<string> LeftArguments { get; } = new();
        private List<string> CenterArguments { get; } = new();
        private List<string> RightArguments { get; } = new();

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

        public void Remove(string arg)
        {
            LeftArguments.Remove(arg);
            CenterArguments.Remove(arg);
            RightArguments.Remove(arg);
        }

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
