using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace EBoxClient.Utils
{
    public class SettingsUtils
    {
        static readonly object locker = new object();
        static Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        public static string GetConfig(string key, string defaultValue = "")
        {
            lock (locker)
            {
                if (!config.AppSettings.Settings.AllKeys.Contains(key))
                {
                    config.AppSettings.Settings.Add(key, defaultValue);
                }
            }

            return config.AppSettings.Settings[key].Value;
        }

        public static void SetConfig(string key, string value)
        {
            lock (locker)
            {
                if (!config.AppSettings.Settings.AllKeys.Contains(key))
                {
                    config.AppSettings.Settings.Add(key, value);
                }
                else
                {
                    config.AppSettings.Settings[key].Value = value;
                }
                config.Save();
            }
            ConfigurationManager.RefreshSection("AppSettings");
        }
    }
}
