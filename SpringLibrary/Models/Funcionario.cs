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
        [Range(1, 8, ErrorMessage = "O código deve ter de 1 a 8 dígitos")]
        public int funcCod { get; set; }

        [Display(Name = "Nome do Funcionário")]
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string funcNome { get; set; }

        [Display(Name = "Nome social do Funcionário")]
        public string funcNomeSoc { get; set; }

        [Display(Name = "Cargo do Funcionário")]
        [Required(ErrorMessage = "G para Gerente, F para Funcionário comum")]
        public string funcCargo { get; set; }

        [Display(Name = "Senha do Funcionário")]
        [Required(ErrorMessage = "Senha obrigatória")]
        public string funcSenha { get; set; }
    }
}