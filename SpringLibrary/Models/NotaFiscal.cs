using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpringLibrary.Models
{
    public class NotaFiscal
    {
        [Display(Name = "Código da Nota Fiscal")]
        public int notaCod { get; set; }

        [Display(Name = "Data de emissão da Nota Fiscal")]
        public DateTime notaDtEmiss { get; set; }

        [Display(Name = "Código do Funcionário")]
        public int funcCod { get; set; }
    }
}