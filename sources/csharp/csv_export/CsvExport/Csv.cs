using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace CsvExport
{
    public class Csv
    {
        private Dictionary<string, StringBuilder> _Csv;
        private bool WithHeader = false;
        private int Line = 0;

        public Csv()
        {
            this._Csv = new Dictionary<string, StringBuilder>
            {
                { 
                    "header",
                    new StringBuilder()
                },
                { 
                    "body",
                    new StringBuilder()
                }
            };
        }

        private void SetUp()
        {
            this._Csv["header"].Clear();
            this._Csv["body"].Clear();
            this.Line = 0;
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
            this.WithHeader = withHeader;
            this.Write(data);

            var extension = Path.GetExtension(path);
            var filePath = !string.IsNullOrWhiteSpace(extension) ?
                path :
                string.Format(
                    "{0}.csv", 
                    path
                );

            File.WriteAllText(
                filePath,
                string.Format(
                    "{0}\r\n{1}",
                    this._Csv["header"].ToString(),
                    this._Csv["body"].ToString()
                )
            );
        }

        private void Write<T>(
            T data
        )
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
                    this._Csv["body"].Append("\r\n");
                }

                this.Line--;
            }
            else
            {
                this.Line++;
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
                        this.Line--;
                        this.Write(value);
                    }
                    else if (isList)
                    {
                        var list = value as IEnumerable;
                        this.Write(list);
                    }
                    else
                    {
                        if (this.WithHeader && this.Line == 1)
                        {
                            var name = property.Name;
                            if (!string.IsNullOrEmpty(name))
                            {
                                this._Csv["header"].AppendFormat(" {0};", name);
                            }
                        }

                        if (value != null)
                        {
                            this._Csv["body"].AppendFormat(" {0};", value);
                        }
                    }
                }
            }
        }
    }
}