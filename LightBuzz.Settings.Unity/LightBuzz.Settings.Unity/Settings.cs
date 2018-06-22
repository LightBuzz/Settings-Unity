using System;
using UnityEngine;

namespace LightBuzz.Settings
{
    /// <summary>
    /// Provides some utility methods for setting, getting and deleting application data.
    /// </summary>
    public static class Settings
    {
        /// <summary>
        /// Inserts the specified value to the specified settings key, or creates a new pair.
        /// </summary>
        /// <param name="key">The name of the setting.</param>
        /// <param name="value">The content of the setting.</param>
        public static void Set<T>(string key, T value)
        {
            Type type = typeof(T);

            if (type == typeof(bool))
            {
                PlayerPrefs.SetInt(key, Convert.ToBoolean(value) ? 1 : 0);
            }
            else if (type == typeof(int))
            {
                PlayerPrefs.SetInt(key, Convert.ToInt32(value));
            }
            else if (type == typeof(short))
            {
                PlayerPrefs.SetInt(key, Convert.ToInt16(value));
            }
            else if (type == typeof(long))
            {
                PlayerPrefs.SetString(key, Convert.ToString(value));
            }
            else if (type == typeof(float))
            {
                PlayerPrefs.SetFloat(key, Convert.ToSingle(value));
            }
            else if (type == typeof(double))
            {
                PlayerPrefs.SetString(key, Convert.ToString(value));
            }
            else if (type == typeof(string))
            {
                PlayerPrefs.SetString(key, Convert.ToString(value));
            }
            else if (type == typeof(DateTime))
            {
                PlayerPrefs.SetString(key, Convert.ToString(value));
            }
            else if (type == typeof(Guid))
            {
                PlayerPrefs.SetString(key, Convert.ToString(value));
            }
            else
            {
                PlayerPrefs.SetString(key, Convert.ToString(value));
            }
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
            if (PlayerPrefs.HasKey(key))
            {
                Type type = typeof(T);

                if (type == typeof(bool))
                {
                    return (T)Convert.ChangeType(PlayerPrefs.GetInt(key) == 0 ? false : true, type);
                }

                if (type == typeof(int))
                {
                    return (T)Convert.ChangeType(PlayerPrefs.GetInt(key), type);
                }

                if (type == typeof(short))
                {
                    return (T)Convert.ChangeType(PlayerPrefs.GetInt(key), type);
                }

                if (type == typeof(long))
                {
                    return (T)Convert.ChangeType(long.Parse(PlayerPrefs.GetString(key)), type);
                }

                if (type == typeof(float))
                {
                    return (T)Convert.ChangeType(PlayerPrefs.GetFloat(key), type);
                }

                if (type == typeof(double))
                {
                    return (T)Convert.ChangeType(double.Parse(PlayerPrefs.GetString(key)), type);
                }

                if (type == typeof(string))
                {
                    return (T)Convert.ChangeType(PlayerPrefs.GetString(key), type);
                }

                if (type == typeof(DateTime))
                {
                    return (T)Convert.ChangeType(DateTime.Parse(PlayerPrefs.GetString(key)), type);
                }

                if (type == typeof(Guid))
                {
                    return (T)Convert.ChangeType(new Guid(PlayerPrefs.GetString(key)), type);
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
            if (PlayerPrefs.HasKey(key))
            {
                PlayerPrefs.DeleteKey(key);
            }
        }
    }
}
