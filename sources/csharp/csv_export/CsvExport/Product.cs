using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LINQtoCSV;

namespace CsvExport
{
    public class Product
    {
        [CsvColumn(Name = "ID", FieldIndex = 2)]
        public int ID { get; set; }

        [CsvColumn(Name = "Name", FieldIndex = 3)]
        public string Name { get; set; }
    }
}