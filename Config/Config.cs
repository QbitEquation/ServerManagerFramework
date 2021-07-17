using System.Collections.Generic;
using System.Text;

namespace ServerManagerFramework.Config
{
    /// <summary>
    /// Encoder and decoder class for server-manager.config files.
    /// </summary>
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

        /// <summary>
        /// Initializes a new instance of the Config class.
        /// </summary>
        /// <param name="text">Text to decode.</param>
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

        /// <summary>
        /// Gets the value for a given key. Returns null if none is found.
        /// </summary>
        /// <param name="key">The key to search for.</param>
        /// <returns></returns>
        public string GetValue(string key)
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

        /// <summary>
        /// Sets the value of a given key or creates a new one.
        /// </summary>
        /// <param name="key">The key for the value.</param>
        /// <param name="value">The value that should be stored.</param>
        /// <returns>A new instance with applied changes.</returns>
        public Config SetValue(string key, string value)
        {
            if (KeyValues.ContainsKey(key))
            {
                KeyValues[key] = value;
            }
            else
            {
                KeyValues.Add(key, value);
            }

            return this;
        }

        /// <summary>
        /// Removes a value.
        /// </summary>
        /// <param name="key">The key of the value that should be removed.</param>
        /// <returns>A new instance with applied changes.</returns>
        public Config RemoveValue(string key)
        {
            KeyValues.Remove(key);

            return this;
        }

        /// <summary>
        /// Converts the value of this instance to a System.String.
        /// </summary>
        /// <returns>A string whose value is the same as this instance.</returns>
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
