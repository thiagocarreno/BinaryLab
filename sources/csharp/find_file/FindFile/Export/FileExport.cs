using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindFile.Export
{
    public class FileExport
    {
        private readonly FileExportAbstract _FileExport;

        public FileExport(Enumerators.ExporType type)
        {
            switch (type)
            {
                case Enumerators.ExporType.Text:
                    this._FileExport = new TextExport();
                    break;
                case Enumerators.ExporType.Csv:
                    this._FileExport = new CsvExport();
                    break;
                default:
                    throw new Exception("The type connot be implemented");
            }
        }

        public void Export<T>(
            T data,
            string path
        )
        {
            this._FileExport.Export(data, path);
        }
    }
}