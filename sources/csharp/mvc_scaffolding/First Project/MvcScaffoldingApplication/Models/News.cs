using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcScaffoldingApplication.Models
{
    public class News
    {
        [Key]
        public int IdNews { get; set; }

        [Display(Name = "Título")]
        public string Title { get; set; }

        [Display(Name = "Descrição")]
        public string NewsDescription { get; set; }

        [Display(Name = "Autor")]
        public string Author { get; set; }

        [Display(Name = "Data da Notícia")]
        public DateTime NewsDate { get; set; }

        [Display(AutoGenerateField = false, AutoGenerateFilter = false)]
        public DateTime Created { get; set; }

        [Display(AutoGenerateField = false)]
        public DateTime? Updated { get; set; }

        [Display(AutoGenerateField = false)]
        public long Priority { get; set; }
    }
}