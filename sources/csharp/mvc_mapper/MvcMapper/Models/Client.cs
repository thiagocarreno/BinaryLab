using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMapper.Models
{
    public class Client
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birth { get; set; }
        public bool Active { get; set; }
    }
}