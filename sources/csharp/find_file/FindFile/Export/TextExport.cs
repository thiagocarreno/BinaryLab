using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using FindFile.Models;
using TextExport;

namespace FindFile.Export
{
    public class TextExport
        : FileExportAbstract
    {
        public override void Export<T>(
            T data,
            string path
        )
        {
            if (data == null)
            {
                throw new ArgumentNullException("The data connot be null.");
            }

            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException("The path connot be null.");
            }

            var text = new Text();
            text.Export(data, path);
        }
    }
}