using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpringLibrary.Models
{
    public class Produto
    {
        [Display(Name = "Código do produto")]
        public int prodCod { get; set; }

        [Display(Name = "Nome do produto")]
        public string prodNome { get; set; }

        [Display(Name = "Preço do produto")]
        [RegularExpression(@"R\$ ?\d{1,3}(\.\d{3})*,\d{2}", ErrorMessage = "Coloque um valor real")]
        public decimal prodPreco { get; set; }

        [Display(Name = "Quantidade no estoque")]
        public int prodQtdEst { get; set; }
    }
}