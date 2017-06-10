using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Study.Owin.OData.WebApiApp.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual List<Trip> Trips { get; set; }
    }
}