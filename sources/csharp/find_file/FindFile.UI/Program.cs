using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FindFile.Models;
using System.IO;
using CsvExport;
using FindFile.Export;

namespace FindFile.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Find();
        }

        static void Find()
        {
            var di = new DirectoryInfo(Constants.PathRead);
            var info = Scan(di, Constants.ExtensionsFilter);
            Export(info);
        }

        static List<Info> Scan(DirectoryInfo info, string[] extensions)
        {
            if (info == default(DirectoryInfo))
            {
                throw new ArgumentNullException("The info connot be null.");
            }

            if (extensions == default(string[]))
            {
                throw new ArgumentNullException("The extensions connot be null.");
            }

            List<Info> listInfo = new List<Info>();

            foreach (var extension in extensions)
            {
                var files = info.GetFiles(extension, SearchOption.AllDirectories);

                foreach (var file in files)
                {
                    listInfo.Add(
                        new Info
                        {
                            Name = file.Name,
                            Extension = file.Extension,
                            Path = file.FullName
                        }
                    );
                }
            }

            return listInfo;
        }

        static void Export(List<Info> infoList)
        {
            if (infoList == default(List<Info>))
            {
                throw new ArgumentNullException("The infoList connot be null.");
            }

            var path = string.Format(
                "{0}{1}_{2}.csv",
                Constants.PathWrite,
                Constants.FileNameExport,
                DateTime.Now.ToString("yyyyMMddHHmmssfff")
            );

            string.Concat(Constants.PathWrite, Constants.FileNameExport);
            var file1 = new FileExport(Enumerators.ExporType.Csv);
            file1.Export(infoList, path);

            path = string.Format(
                "{0}{1}_{2}.txt",
                Constants.PathWrite,
                Constants.FileNameExport,
                DateTime.Now.ToString("yyyyMMddHHmmssfff")
            );

            var file2 = new FileExport(Enumerators.ExporType.Text);
            file2.Export(infoList, path);
        }
    }
}