using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using DataTransfer.Properties.Resources;
using DataTransfer.Core;

namespace DataTransfer.ConfigSections.DataTransfer
{
    public class TransferCollection
        : ConfigurationElementCollection, IEnumerable<TransferElement>
    {
        private const string TransferKey = "transfer";

        protected override ConfigurationElement CreateNewElement()
        {
            return new TransferElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TransferElement)element).InvariantName;
        }

        protected override string ElementName
        {
            get
            {
                return TransferKey;
            }
        }

        protected override void BaseAdd(ConfigurationElement element)
        {
            var key = GetElementKey(element);
            if (BaseGet(key) != null)
            {
                throw new InvalidOperationException(Strings.TransferInvariantRepeatedInConfig(key));
            }

            base.BaseAdd(element);
        }

        protected override void BaseAdd(int index, ConfigurationElement element)
        {
            var key = GetElementKey(element);
            if (BaseGet(key) != null)
            {
                throw new InvalidOperationException(Strings.TransferInvariantRepeatedInConfig(key));
            }

            base.BaseAdd(index, element);
        }

        public TransferElement AddTransfer(
            string inavariantName,
            bool enable,
            FromElement from,
            ToElement to
        )
        {
            Check.NotNull(() => inavariantName);

            var element = (TransferElement)CreateNewElement();
            element.InvariantName = inavariantName;
            element.Enable = enable;
            element.From = from;
            element.To = to;
            base.BaseAdd(element);
            return element;
        }

        public new IEnumerator<TransferElement> GetEnumerator()
        {
            var keys = this.BaseGetAllKeys();
            foreach (var key in keys)
            {
                var element = (TransferElement)BaseGet(key);
                if (element.Enable)
                {
                    yield return element;
                }
            }
        }
    }
}