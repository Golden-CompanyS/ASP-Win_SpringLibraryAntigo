using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpringLibrary.Models
{
    public class ItemVenda
    {
        [Display(Name = "Código de Item Venda")]
        public int itVendaCod { get; set; }

        [Display(Name = "Código do produto")]
        public int prodCod { get; set; }

        [Display(Name = "Quantidade de itens da venda")]
        public int itVendaQtd { get; set; }

        [Display(Name = "Código da Nota Fiscal")]
        public int notaCod { get; set; }

        [Display(Name = "Código da Locação")]
        public int locDesc { get; set; }

        [Display(Name = "Código da Restauração")]
        public int restCod { get; set; }
    }
}