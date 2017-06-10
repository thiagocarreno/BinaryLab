using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using DataTransfer.ConfigSections;
using System.Collections.Specialized;

namespace DataTransfer
{
    public class Configuration
        : ConfigurationSection
    {
        private const string DataTransferKey = "dataTransfer";

        [ConfigurationProperty(DataTransferKey, IsRequired = false)]
        public static DataTransferSection DataTransfer
        {
            get
            {
                return (DataTransferSection)ConfigurationManager.GetSection(DataTransferKey);
            }
        }
    }
}