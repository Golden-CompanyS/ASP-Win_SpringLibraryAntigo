using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpringLibrary.Models
{
    public class Funcionario
    {
        [Display(Name = "Código do Funcionário")]
        public int funcCod { get; set; }

        [Display(Name = "Nome do Funcionário")]
        public string funcNome { get; set; }

        [Display(Name = "Nome social do Funcionário")]
        public string funcNomeSoc { get; set; }

        [Display(Name = "Cargo do Funcionário")]
        public string funcCargo { get; set; }

        [Display(Name = "Senha do Funcionário")]
        public string funcSenha { get; set; }
    }
}