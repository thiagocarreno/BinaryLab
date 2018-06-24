using Infodinamica.Framework.Exportable.Engines.Excel;
using System;
using System.Collections.Generic;

namespace Study.ExportToExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            var totalRows = 10;
            if (args.Length > 0)
                int.TryParse(args[0], out totalRows);

            var list = new List<Sample>(totalRows);

            for (int i = 1; i <= totalRows; i++)
                list.Add(new Sample
                {
                    Id = i,
                    Name = $"Sample {i}",
                });

            var engine = new ExcelExportEngine();
            engine.SetFormat(ExcelVersion.XLSX);
            engine.AddData(list);
            var extenssao = ExcelVersion.XLSX.ToString().ToLower();
            var path = $"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}Teste_{totalRows}.{extenssao}";
            engine.Export(path);
        }
    }

    public class Sample
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}