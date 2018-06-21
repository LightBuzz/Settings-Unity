using System;
using UnityEngine;

namespace LightBuzz.Settings
{
    /// <summary>
    /// Provides some utility methods for setting, getting and deleting application data.
    /// </summary>
    public static class Settings
    {
        private readonly static string Prefix = "lightbuzz_type_";

        /// <summary>
        /// Inserts the specified value to the specified settings key, or creates a new pair.
        /// </summary>
        /// <param name="key">The name of the setting.</param>
        /// <param name="value">The content of the setting.</param>
        public static void Set(string key, object value)
        {
            PlayerPrefs.SetString(Prefix + key, value.GetType().ToString());

            if (value is int)
            {
                PlayerPrefs.SetInt(key, (int)value);
            }
            if (value is bool)
            {
                PlayerPrefs.SetInt(key, (bool)value ? 1 : 0);
            }
            else if (value is double)
            {
                PlayerPrefs.SetFloat(key, (float)value);
            }
            else if (value is float)
            {
                PlayerPrefs.SetFloat(key, (float)value);
            }
            else if (value is string)
            {
                PlayerPrefs.SetString(key, (string)value);
            }
            else
            {
                PlayerPrefs.SetString(key, value.ToString());
            }
        }

        /// <summary>
        /// Retrieves the contents of the specified setting key.
        /// </summary>
        /// <param name="key">The name of the setting.</param>
        /// <returns>The content of the specified setting.</returns>
        public static object Get(string key)
        {
            return Get(key, default(object));
        }

        /// <summary>
        /// Retrieves the contents of the specified setting key.
        /// </summary>
        /// <param name="key">The name of the setting.</param>
        /// <param name="defaultValue">The default value returned, if the key isn't found.</param>
        /// <returns>The content of the specified setting.</returns>
        public static object Get(string key, object defaultValue)
        {
            if (PlayerPrefs.HasKey(Prefix + key))
            {
                Type type = Type.GetType(PlayerPrefs.GetString(Prefix + key));

                if (type == typeof(int))
                {
                    return PlayerPrefs.GetInt(key);
                }

                if (type == typeof(bool))
                {
                    return PlayerPrefs.GetInt(key);
                }

                if (type == typeof(float))
                {
                    return PlayerPrefs.GetFloat(key);
                }

                if (type == typeof(double))
                {
                    return PlayerPrefs.GetFloat(key);
                }

                if (type == typeof(string))
                {
                    return PlayerPrefs.GetString(key);
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
            if (PlayerPrefs.HasKey(Prefix + key))
            {
                PlayerPrefs.DeleteKey(Prefix + key);
            }

            if (PlayerPrefs.HasKey(key))
            {
                PlayerPrefs.DeleteKey(key);
            }
        }
    }
}
