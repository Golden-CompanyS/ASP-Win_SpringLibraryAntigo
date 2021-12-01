using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpringLibrary.Models
{
    public class Editora
    {
        [Display(Name = "Código da editora")]
        public int editCod { get; set; }

        [Display(Name = "Nome da editora")]
        public string editNome { get; set; }
    }
}