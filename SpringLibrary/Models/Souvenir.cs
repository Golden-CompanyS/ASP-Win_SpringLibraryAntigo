using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpringLibrary.Models
{
    public class Souvenir
    {
        [Display(Name = "Código do Souvenir")]
        public int souvCod { get; set; }

        [Display(Name = "Nome do Souvenir")]
        public string souvNome { get; set; }

        [Display(Name = "Dimensões do Souvenir")]
        public string souvDimen { get; set; }

        [Display(Name = "Material do Souvenir")]
        public string souvMaterial { get; set; }

        [Display(Name = "Tipo do Souvenir")]
        public string souvTip { get; set; }
    }
}