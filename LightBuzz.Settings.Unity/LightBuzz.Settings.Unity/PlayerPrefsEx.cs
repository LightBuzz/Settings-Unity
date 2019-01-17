using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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

        private readonly string SettingsFileName = "Settings.lbz";

        private string _dataPath;
        private bool _initialized = false;

        private Dictionary<string, string> _settings;

        /// <summary>
        /// The directory where the settings key/values will be stored.
        /// </summary>
        public string SettingsFilePath { get; private set; }

        public void Initialize(string root)
        {
            if (root != _dataPath)
            {
                _dataPath = root;
                _initialized = false;
            }

            if (!_initialized)
            {
                SettingsFilePath = Path.Combine(_dataPath, SettingsFileName);

                if (!File.Exists(SettingsFilePath))
                {
                    File.WriteAllText(SettingsFilePath, string.Empty, Encoding.UTF8);
                }

                _initialized = true;
            }

            _settings = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(SettingsFilePath));

            if (_settings == null)
            {
                _settings = new Dictionary<string, string>();
            }
        }

        public void Set(string key, string value)
        {
            Check();

            if (_settings.ContainsKey(key))
            {
                _settings[key] = value;
            }
            else
            {
                _settings.Add(key, value);
            }

            Save();
        }

        public string Get(string key)
        {
            Check();
            
            if (!_settings.ContainsKey(key))
            {
                Set(key, default(string));
            }

            return _settings[key];
        }

        public void Delete(string key)
        {
            Check();

            if (_settings.ContainsKey(key))
            {
                _settings.Remove(key);
            }

            Save();
        }

        public bool Has(string key)
        {
            Check();

            return _settings.ContainsKey(key);
        }

        private void Check()
        {
            if (!_initialized) throw new Exception("Settings are not initialized. Call the Settings.Initialize() method from Unity's main thread.");
        }

        public void DeleteAll()
        {
            if (_settings != null)
            {
                _settings.Clear();
            }

            _settings = new Dictionary<string, string>();

            Save();
        }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(_settings);

            File.WriteAllText(SettingsFilePath, json);
        }
    }
}
