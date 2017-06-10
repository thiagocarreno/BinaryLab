using System.ComponentModel.DataAnnotations;

namespace Study.Owin.OData.WebApiApp.Models
{
    public class Trip
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}