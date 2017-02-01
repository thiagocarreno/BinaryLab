using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindFile.Export
{
    public abstract class FileExportAbstract
    {
        public abstract void Export<T>(T data, string path);
    }
}