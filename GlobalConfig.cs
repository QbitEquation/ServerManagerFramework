using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ServerManagerFramework
{
    /// <summary>
    /// Saves and loads global settings.
    /// </summary>
    public static class GlobalConfig
    {
        private const string MANAGERPATH = @"\Server-Manager";
        /// <summary>
        /// The path to the Server-Manager folder in AppData (Roaming).
        /// </summary>
        public static string ManagerPath => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + MANAGERPATH;
        /// <summary>
        /// The configured path to the server folder.
        /// </summary>
        public static string ServersPath { get; private set; }
        /// <summary>
        /// The configured path to the backups folder.
        /// </summary>
        public static string BackupsPath { get; private set; }

        private static Dictionary<string, string> KeyValues { get; } = new();

        private const string configPath = @"\global.config";

        /// <summary>
        /// Loads the config settings.
        /// </summary>
        public static void Load()
        {
            Directory.CreateDirectory(ManagerPath);

            if (!File.Exists(ManagerPath + configPath))
            {
                File.Create(ManagerPath + configPath).Dispose();
            }
            string text = File.ReadAllText(ManagerPath + configPath);
            string[] lines = text.Split('\n');

            foreach (string line in lines)
            {
                string[] keyValue = line.Split('=', 2);

                if (keyValue.Length == 2)
                {
                    KeyValues.Add(keyValue[0], keyValue[1]);
                }
            }

            if (GetValue("serverspath") == null)
            {
                SetValue("serverspath", ManagerPath + @"\Servers");
            }
            if (GetValue("backupspath") == null)
            {
                SetValue("backupspath", ManagerPath + @"\Backups");
            }

            _ = Save();

            ServersPath = GetValue("serverspath");
            BackupsPath = GetValue("backupspath");
        }

        /// <summary>
        /// Saves the config settings.
        /// </summary>
        public static async Task Save()
        {
            StringBuilder text = new();

            foreach (KeyValuePair<string, string> keyValue in KeyValues)
            {
                text.Append(keyValue.Key);
                text.Append('=');
                text.Append(keyValue.Value);
                text.Append('\n');
            }

            await File.WriteAllTextAsync(configPath, text.ToString());
        }

        /// <summary>
        /// Gets a value for a given key. Returns null if none is found.
        /// </summary>
        /// <param name="key">The key to search for.</param>
        public static string GetValue(string key)
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
        public static void SetValue(string key, string value)
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

        /// <summary>
        /// Removes a value.
        /// </summary>
        /// <param name="key">The key of the value that should be removed.</param>
        public static void RemoveValue(string key)
        {
            KeyValues.Remove(key);
        }
    }
}
