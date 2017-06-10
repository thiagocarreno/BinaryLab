using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace FindFile
{
    public static class Constants
    {
        private static string GetConfig(string key)
        {
            string configuration = ConfigurationManager.AppSettings[key];

            if (configuration == null)
            {
                var exMessage = String.Format("Configuração {0} não encontrada", key);
                throw new InvalidOperationException(exMessage);
            }

            return configuration;
        }

        public static string PathRead
        {
            get
            {
                return GetConfig("PathRead");
            }
        }

        public static string PathWrite
        {
            get
            {
                return GetConfig("PathWrite");
            }
        }

        public static string FileNameExport
        {
            get
            {
                return GetConfig("FileNameExport");
            }
        }

        public static string[] ExtensionsFilter
        {
            get
            {
                string[] result = default(string[]);
                var configValue = GetConfig("ExtensionsFilter");

                if (!string.IsNullOrWhiteSpace(configValue))
                {
                    result = configValue.Split(',');

                    if (result.Length > 1)
                    {
                        for (int i = 0; i < result.Length; i++)
                        {
                            var value = result[i].Trim();

                            if (Char.IsLetter(value[0]))
                            {
                                value = string.Format(
                                    "*.{0}",
                                    value
                                );
                            }
                            else if (value.StartsWith("."))
                            {
                                value = string.Format(
                                    "*{0}",
                                    value
                                );
                            }
                            else if (value.StartsWith("*"))
                            {
                                if (value[1].Equals('.'))
                                {
                                    value = string.Format(
                                        "*{0}",
                                        value.Remove(0, 1)
                                    );
                                }
                                else
                                {
                                    value = string.Format(
                                        "*.{0}",
                                        value.Remove(0, 1)
                                    );
                                }
                            }

                            result[i] = value;
                        }
                    }
                }

                return result;
            }
        }
    }
}