using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace DataTransfer.ConfigSections.DataTransfer
{
    public class TransferElement
        : ConfigurationElement
    {
        private const string InvariantNameKey = "invariantName";
        private const string EnableKey = "enable";
        private const string FromEmptyWarningEnableKey = "fromEmptyWarningEnable";
        private const string FromEmptyWarningToKey = "fromEmptyWarningTo";
        private const string FromEmptyWarningCcKey = "fromEmptyWarningCc";
        private const string FromEmptyWarningSubjectKey = "fromEmptyWarningSubject";
        private const string FromEmptyWarningBodyKey = "fromEmptyWarningBody";
        private const string FromKey = "from";
        private const string ToKey = "to";

        [ConfigurationProperty(InvariantNameKey, IsRequired = true)]
        public virtual string InvariantName
        {
            get
            {
                return (string)this[InvariantNameKey];
            }
            set 
            {
                this[InvariantNameKey] = value;
            }
        }

        [ConfigurationProperty(EnableKey, IsRequired = false, DefaultValue = true)]
        public virtual bool Enable
        {
            get
            {
                return (bool)this[EnableKey];
            }
            set
            {
                this[EnableKey] = value;
            }
        }

        [ConfigurationProperty(FromEmptyWarningEnableKey, IsRequired = false, DefaultValue = false)]
        public virtual bool FromEmptyWarningEnable
        {
            get
            {
                return (bool)this[FromEmptyWarningEnableKey];
            }
            set
            {
                this[FromEmptyWarningEnableKey] = value;
            }
        }

        [ConfigurationProperty(FromEmptyWarningToKey, IsRequired = false)]
        public virtual string FromEmptyWarningTo
        {
            get
            {
                return (string)this[FromEmptyWarningToKey];
            }
            set
            {
                this[FromEmptyWarningToKey] = value;
            }
        }

        [ConfigurationProperty(FromEmptyWarningCcKey, IsRequired = false)]
        public virtual string FromEmptyWarningCc
        {
            get
            {
                return (string)this[FromEmptyWarningCcKey];
            }
            set
            {
                this[FromEmptyWarningCcKey] = value;
            }
        }

        [ConfigurationProperty(FromEmptyWarningSubjectKey, IsRequired = false)]
        public virtual string FromEmptyWarningSubject
        {
            get
            {
                return (string)this[FromEmptyWarningSubjectKey];
            }
            set
            {
                this[FromEmptyWarningSubjectKey] = value;
            }
        }

        [ConfigurationProperty(FromEmptyWarningBodyKey, IsRequired = false)]
        public virtual string FromEmptyWarningBody
        {
            get
            {
                return (string)this[FromEmptyWarningBodyKey];
            }
            set
            {
                this[FromEmptyWarningBodyKey] = value;
            }
        }

        [ConfigurationProperty(FromKey, IsRequired = false)]
        public virtual FromElement From
        {
            get
            {
                return (FromElement)this[FromKey];
            }
            set
            {
                this[FromKey] = value;
            }
        }

        [ConfigurationProperty(ToKey, IsRequired = false)]
        public virtual ToElement To
        {
            get
            {
                return (ToElement)this[ToKey];
            }
            set
            {
                this[ToKey] = value;
            }
        }
    }
}