using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using DataTransfer.ConfigSections.DataTransfer.Abstraction;

namespace DataTransfer.ConfigSections.DataTransfer
{
    public class FromElement
        : TransferElementAbstract
    {
        private const string SearchPatternKey = "searchPattern";
        private const string DeleteAfterKey = "deleteAfter";

        [ConfigurationProperty(SearchPatternKey, DefaultValue = "*", IsKey = true)]
        public string SearchPattern
        {
            get
            {
                return (string)this[SearchPatternKey];
            }
        }

        [ConfigurationProperty(DeleteAfterKey, DefaultValue = false, IsKey = true)]
        public bool DeleteAfter
        {
            get
            {
                return (bool)this[DeleteAfterKey];
            }
        }
    }
}