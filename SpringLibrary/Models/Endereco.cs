using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpringLibrary.Models
{
    public class Endereco
    {
        [Display(Name = "CEP do endereço")]
        public string CEP { get; set; }

        [Display(Name = "Logadouro do endereço")]
        public string lograd { get; set; }

        [Display(Name = "Código da Cidade")]
        public int cidCod { get; set; }

        [Display(Name = "Unidade Federativa")]
        public string UF { get; set; }
    }
}