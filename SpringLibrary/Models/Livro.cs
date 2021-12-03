using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpringLibrary.Models
{
    public class Livro
    {
        [Display(Name = "ISBN do livro")]
        [RegularExpression(@"^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d-]+$", ErrorMessage = "Número inválido")]
        public string isbn { get; set; }

        [Display(Name = "Título do livro em Português")]
        public string livTitulo { get; set; }

        [Display(Name = "Título do livro em seu idioma original")]
        public string livTituloOriginal { get; set; }

        [Display(Name = "Edição do livro")]
        public string livEdicao { get; set; }

        [Display(Name = "Ano de lançamento do livro")]
        public string livAno { get; set; }

        [Display(Name = "Número de páginas do livro")]
        public int livNumPag { get; set; }

        [Display(Name = "Código do gênero do livro")]
        public int genCod { get; set; }

        [Display(Name = "Código da editora do livro")]
        public int editCod { get; set; }
    }
}