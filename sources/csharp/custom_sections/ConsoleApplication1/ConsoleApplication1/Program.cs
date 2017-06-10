using ConsoleApplication1;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = ConfigurationManager.GetSection("reportsSection") as ReportsSection;
            foreach (Report report in config.Reports)
            {
                var reportName = report.Name;

                foreach (Sheet sheet in report.Sheets)
                {
                    var sheetName = sheet.Name;
                }
            }
        }
    }
}
