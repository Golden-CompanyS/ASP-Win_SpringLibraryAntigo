using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpringLibrary.Models
{
    public class Cidade
    {
        [Display(Name = "Código da Cidade")]
        public int cidCod { get; set; }

        [Display(Name = "Nome da Cidade")]
        public string cidNome { get; set; }
    }
}