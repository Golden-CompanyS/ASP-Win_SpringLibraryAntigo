using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpringLibrary.Models
{
    public class Genero
    {
        [Display(Name = "Código do gênero do livro")]
        public int genCod { get; set; }

        [Display(Name = "Nome do gênero do livro")]
        public string genNome { get; set; }
    }
}