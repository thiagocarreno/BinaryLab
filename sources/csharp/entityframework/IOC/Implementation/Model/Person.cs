using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IOC.FW.Abstraction.Model;

namespace IOC.Implementation.Model
{
    [Table("Person")]
    public class Person
        : IBaseModel
    {
        [Key]
        public int IdPerson { get; set; }

        public int IdOcupation { get; set; }

        //[ForeignKey("IdOcupation")]
        public virtual Ocupation Ocupation { get; set; }

        public string PersonName { get; set; }

        public string Gender { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Updated { get; set; }

        public bool Activated { get; set; }
    }
}