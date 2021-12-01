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
        public decimal prodPreco { get; set; }

        [Display(Name = "Quantidade no estoque")]
        public int prodQtdEst { get; set; }
    }
}