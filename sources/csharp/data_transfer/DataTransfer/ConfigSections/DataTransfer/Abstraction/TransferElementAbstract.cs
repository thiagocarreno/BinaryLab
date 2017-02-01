using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace DataTransfer.ConfigSections.DataTransfer.Abstraction
{
    public abstract class TransferElementAbstract
        : ConfigurationElement
    {
        private const string IsFtpKey = "isFtp";
        private const string HostKey = "host";
        private const string PortKey = "port";
        private const string UserNameKey = "userName";
        private const string PasswordKey = "password";
        private const string PathKey = "path";

        [ConfigurationProperty(IsFtpKey, DefaultValue = false, IsKey = true)]
        public virtual bool IsFtp
        {
            get
            {
                return (bool)this[IsFtpKey];
            }
        }

        [ConfigurationProperty(HostKey, DefaultValue = default(string))]
        public virtual string Host
        {
            get
            {
                return (string)this[HostKey];
            }
        }

        [ConfigurationProperty(PortKey, DefaultValue = 21)]
        public virtual int Port
        {
            get
            {
                return (int)this[PortKey];
            }
        }

        [ConfigurationProperty(UserNameKey, DefaultValue = default(string))]
        public virtual string UserName
        {
            get
            {
                return (string)this[UserNameKey];
            }
        }

        [ConfigurationProperty(PasswordKey, DefaultValue = default(string))]
        public virtual string Password
        {
            get
            {
                return (string)this[PasswordKey];
            }
        }

        [ConfigurationProperty(PathKey, DefaultValue = default(string))]
        public virtual string Path
        {
            get
            {
                return (string)this[PathKey];
            }
        }
    }
}