using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextExport
{
    public class Data<T>
        where T : class
    {
        public string State { get; set; }


        public List<T> Products { get; set; }
    }
}