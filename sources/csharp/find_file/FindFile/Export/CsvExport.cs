using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FindFile.Models;
using CsvExport;

namespace FindFile.Export
{
    public class CsvExport
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

            var csv = new Csv();
            csv.Export(data, path);
        }
    }
}