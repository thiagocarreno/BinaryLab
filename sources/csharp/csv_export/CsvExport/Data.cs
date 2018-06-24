using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LINQtoCSV;

namespace CsvExport
{
    public class Data<T>
        where T : class
    {
        [CsvColumn(Name = "State", FieldIndex = 1)]
        public string State { get; set; }

        public List<T> Products { get; set; }
    }
}