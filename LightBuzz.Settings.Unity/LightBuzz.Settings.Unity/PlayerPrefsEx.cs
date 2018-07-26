using System;
using System.IO;

namespace LightBuzz.Settings
{
    internal class PlayerPrefsEx
    {
        #region Singleton

        private static volatile PlayerPrefsEx _instance;
        private static object _syncRoot = new Object();

        private PlayerPrefsEx()
        {
        }

        public static PlayerPrefsEx Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new PlayerPrefsEx();
                        }
                    }
                }

                return _instance;
            }
        }

        #endregion

        private readonly string SettingsFolderName = "Settings";

        private string _dataPath;
        private bool _initialized = false;

        /// <summary>
        /// The directory where the settings key/values will be stored.
        /// </summary>
        public string SettingsDirectory { get; private set; }

        public void Initialize(string root)
        {
            if (root != _dataPath)
            {
                _dataPath = root;
                _initialized = false;
            }

            if (!_initialized)
            {
                SettingsDirectory = Path.Combine(_dataPath, SettingsFolderName);

                if (!Directory.Exists(SettingsDirectory))
                {
                    Directory.CreateDirectory(SettingsDirectory);
                }

                _initialized = true;
            }
        }

        public void Set(string key, string value)
        {
            Check();

            string file = Path.Combine(SettingsDirectory, key);

            if (!File.Exists(file))
            {
                File.Create(file).Close();
            }

            File.WriteAllText(file, value);
        }

        public string Get(string key)
        {
            Check();

            string file = Path.Combine(SettingsDirectory, key);

            if (!File.Exists(file))
            {
                File.Create(file).Close();
            }

            return File.ReadAllText(file);
        }

        public void Delete(string key)
        {
            Check();

            string file = Path.Combine(SettingsDirectory, key);

            if (File.Exists(file))
            {
                File.Delete(file);
            }
        }

        public bool Has(string key)
        {
            Check();

            string file = Path.Combine(SettingsDirectory, key);

            return File.Exists(file);
        }

        private void Check()
        {
            if (!_initialized) throw new Exception("Settings are not initialized. Call the Settings.Initialize() method from Unity's main thread.");
        }
    }
}
