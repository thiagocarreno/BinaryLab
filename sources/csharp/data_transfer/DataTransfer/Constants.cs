using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Reflection;
using DataTransfer.Properties.Resources;

namespace DataTransfer
{
    public static class Constants
    {
        private static readonly string AssemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        private static string GetConfig(string key)
        {
            string configuration = ConfigurationManager.AppSettings[key];

            if (configuration == null)
            {
                throw new InvalidOperationException(Strings.ConfigurationNotFound(key));
            }

            return configuration;
        }

        public static string LOG_RELATIVE_PATH
        {
            get
            {
                return string.Concat(AssemblyPath, GetConfig("LOG_RELATIVE_PATH"));
            }
        }

        public static string LOG_FILE_NAME
        {
            get
            {
                return GetConfig("LOG_FILE_NAME");
            }
        }

        public static string LOG_EMAIL_SUBJECT
        {
            get
            {
                return GetConfig("LOG_EMAIL_SUBJECT");
            }
        }

        public static string[] LOG_EMAILS
        {
            get
            {
                var value = GetConfig("LOG_EMAILS");
                return value.Split(',');
            }
        }
    }
}