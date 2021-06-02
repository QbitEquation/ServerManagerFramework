using System.Collections.Generic;
using System.Text;

namespace ServerManagerFramework
{
    public struct Config
    {
        private Dictionary<string, string> keyValues;

        private Dictionary<string, string> KeyValues
        {
            get
            {
                if (keyValues == null)
                {
                    keyValues = new Dictionary<string, string>();
                }

                return keyValues;
            }
        }

        public Config(string text)
        {
            keyValues = new();

            string[] lines = text.Split('\n');

            foreach (string line in lines)
            {
                string[] keyValue = line.Split('=', 2);

                if (keyValue.Length == 2)
                {
                    KeyValues.Add(keyValue[0], keyValue[1]);
                }
            }
        }

        public string FindValue(string key)
        {
            if (KeyValues.ContainsKey(key))
            {
                return KeyValues[key];
            }
            else
            {
                return null;
            }
        }

        public void AddValue(string key, string value)
        {
            if (KeyValues.ContainsKey(key))
            {
                KeyValues[key] = value;
            }
            else
            {
                KeyValues.Add(key, value);
            }
        }

        public void RemoveValue(string key)
        {
            KeyValues.Remove(key);
        }

        public override string ToString()
        {
            StringBuilder text = new();

            foreach (KeyValuePair<string, string> keyValue in KeyValues)
            {
                text.Append(keyValue.Key);
                text.Append('=');
                text.Append(keyValue.Value);
                text.Append('\n');
            }

            return text.ToString();
        }
    }
}
