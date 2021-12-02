using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpringLibrary.Models
{
    public class Autor
    {
        [Display(Name = "Código do autor")]
        public int autCod { get; set; }

        [Display(Name = "Nome do autor")]
        public string autNome { get; set; }
    }
}