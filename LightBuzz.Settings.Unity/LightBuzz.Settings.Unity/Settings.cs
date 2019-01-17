using System;
using System.Globalization;

namespace LightBuzz.Settings
{
    /// <summary>
    /// Provides some utility methods for setting, getting and deleting application data.
    /// </summary>
    public static class Settings
    {
        /// <summary>
        /// Initializes the settings module.
        /// </summary>
        public static void Initialize()
        {
            Initialize(UnityEngine.Application.persistentDataPath);
        }

        /// <summary>
        /// Initializes the settings module.
        /// </summary>
        /// <param name="root">The root of the application, where the settings folder will be stored.</param>
        public static void Initialize(string root)
        {
            PlayerPrefsEx.Instance.Initialize(root);
        }

        /// <summary>
        /// Inserts the specified value to the specified settings key, or creates a new pair.
        /// </summary>
        /// <param name="key">The name of the setting.</param>
        /// <param name="value">The content of the setting.</param>
        public static void Set<T>(string key, T value)
        {
            PlayerPrefsEx.Instance.Set(key, Convert.ToString(value));
        }

        /// <summary>
        /// Retrieves the contents of the specified setting key.
        /// </summary>
        /// <param name="key">The name of the setting.</param>
        /// <returns>The content of the specified setting.</returns>
        public static T Get<T>(string key)
        {
            return Get(key, default(T));
        }

        /// <summary>
        /// Retrieves the contents of the specified setting key.
        /// </summary>
        /// <param name="key">The name of the setting.</param>
        /// <param name="defaultValue">The default value returned, if the key isn't found.</param>
        /// <returns>The content of the specified setting.</returns>
        public static T Get<T>(string key, T defaultValue)
        {
            if (PlayerPrefsEx.Instance.Has(key))
            {
                Type type = typeof(T);

                string value = PlayerPrefsEx.Instance.Get(key);

                if (type == typeof(bool))
                {
                    return (T)Convert.ChangeType(bool.Parse(value), type);
                }

                if (type == typeof(int))
                {
                    return (T)Convert.ChangeType(int.Parse(value, CultureInfo.InvariantCulture), type);
                }

                if (type == typeof(short))
                {
                    return (T)Convert.ChangeType(short.Parse(value, CultureInfo.InvariantCulture), type);
                }

                if (type == typeof(long))
                {
                    return (T)Convert.ChangeType(long.Parse(value, CultureInfo.InvariantCulture), type);
                }

                if (type == typeof(float))
                {
                    return (T)Convert.ChangeType(float.Parse(value, CultureInfo.InvariantCulture), type);
                }

                if (type == typeof(double))
                {
                    return (T)Convert.ChangeType(double.Parse(value, CultureInfo.InvariantCulture), type);
                }

                if (type == typeof(string))
                {
                    return (T)Convert.ChangeType(value, type);
                }

                if (type == typeof(DateTime))
                {
                    return (T)Convert.ChangeType(DateTime.Parse(value, CultureInfo.InvariantCulture), type);
                }

                if (type == typeof(Guid))
                {
                    return (T)Convert.ChangeType(new Guid(value), type);
                }
            }

            return defaultValue;
        }

        /// <summary>
        /// Deletes the specified setting.
        /// </summary>
        /// <param name="key">The name of the setting.</param>
        public static void Remove(string key)
        {
            PlayerPrefsEx.Instance.Delete(key);
        }

        /// <summary>
        /// USE CAUTIOUSLY! This method will delete all of the Settings!
        /// </summary>
        public static void DeleteAll()
        {
            PlayerPrefsEx.Instance.DeleteAll();
        }
    }
}
