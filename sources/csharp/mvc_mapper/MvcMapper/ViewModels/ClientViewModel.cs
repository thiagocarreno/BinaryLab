using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcMapper.ViewModels
{
    public class ClientViewModel
    {
        [Required(ErrorMessage = "Preencher campo Nome")]
        public string Name { get; set; }
        public string LastName { get; set; }

        [Required(ErrorMessage = "Preencher campo Data de Nascimento")]
        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime Birth { get; set; }

        public bool Active { get; set; }

        public int LuckyNumber { get; set; }
    }
}