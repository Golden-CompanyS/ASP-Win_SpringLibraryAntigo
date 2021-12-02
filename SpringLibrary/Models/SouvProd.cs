using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpringLibrary.Models
{
    public class SouvProd
    {
        [Display(Name = "Código do Souvenir")]
        public int souvCod { get; set; }

        [Display(Name = "Código do produto")]
        public int prodCod { get; set; }
    }
}