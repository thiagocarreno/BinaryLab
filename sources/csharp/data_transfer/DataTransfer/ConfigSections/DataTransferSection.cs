using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using DataTransfer.ConfigSections.DataTransfer;

namespace DataTransfer.ConfigSections
{
    public class DataTransferSection
        : ConfigurationSection
    {
        private const string TransferCollectionKey = "transfers";
        private const string TransferAddItemKey = "transfer";

        [ConfigurationProperty(TransferCollectionKey, IsRequired = false)]
        [ConfigurationCollection(typeof(TransferCollection), AddItemName = TransferAddItemKey)]
        public virtual TransferCollection Transfers
        {
            get
            {
                return (TransferCollection)base[TransferCollectionKey];
            }
        }
    }
}