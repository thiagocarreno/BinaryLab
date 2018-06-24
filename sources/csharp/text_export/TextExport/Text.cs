using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace TextExport
{
    public class Text
    {
        private StringBuilder _Text;

        public Text()
        {
            this._Text = new StringBuilder();
        }

        private void SetUp()
        {
            this._Text.Clear();
        }

        private bool IsComplexType(object dataValue)
        {
            if (dataValue == null)
            {
                throw new ArgumentNullException("The dataValue cannot be null.");
            }

            var type = dataValue.GetType();
            return !(type == typeof(object) || Type.GetTypeCode(type) != TypeCode.Object);
        }

        private bool IsList(object dataValue)
        {
            if (dataValue == null)
            {
                throw new ArgumentNullException("The dataValue cannot be null.");
            }

            var type = dataValue.GetType();
            return type.IsGenericType && dataValue is IEnumerable;
        }

        public void Export<T>(
            T data,
            string path
        )
        {
            this.Export(data, path, true);
        }

        public void Export<T>(
            T data,
            string path,
            bool withHeader
        )
        {
            if (data == null)
            {
                throw new ArgumentNullException("The data cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException("The path cannot be null.");
            }

            this.SetUp();
            this.Write(data);

            var extension = Path.GetExtension(path);
            var filePath = !string.IsNullOrWhiteSpace(extension) ?
                path :
                string.Format(
                    "{0}.txt",
                    path
                );

            File.WriteAllText(
                filePath,
                this._Text.ToString()
            );
        }

        private void Write<T>(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("The data cannot be null.");
            }

            var isList = this.IsList(data);
            if (isList)
            {
                var listData = data as IEnumerable;
                foreach (var item in listData)
                {
                    this.Write(item);
                    this._Text.Append("\r\n");
                }
            }
            else
            {
                var properties = data
                    .GetType()
                    .GetProperties();

                foreach (var property in properties)
                {
                    var value = property.GetValue(data, null);
                    var isComplexType = this.IsComplexType(value);
                    isList = this.IsList(value);

                    if (isComplexType)
                    {
                        this.Write(value);
                    }
                    else if (isList)
                    {
                        var list = value as IEnumerable;
                        this.Write(list);
                    }
                    else
                    {
                        var name = property.Name;
                        this._Text.AppendFormat("{0}: {1} ", name, value);
                    }
                }
            }
        }
    }
}