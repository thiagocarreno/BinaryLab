using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using DataTransfer.ConfigSections.DataTransfer.Abstraction;

namespace DataTransfer.ConfigSections.DataTransfer
{
    public class ToElement
        : TransferElementAbstract
    {
        private const string MaintainStructureKey = "maintainStructure";

        [ConfigurationProperty(MaintainStructureKey, DefaultValue = true, IsKey = true)]
        public bool MaintainStructure
        {
            get
            {
                return (bool)this[MaintainStructureKey];
            }
        }
    }
}