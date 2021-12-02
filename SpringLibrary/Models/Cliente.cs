using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpringLibrary.Models
{
    public class Cliente
    {
        [Display(Name = "Código do Cliente")]
        public int cliCod { get; set; }

        [Display(Name = "CPF do Cliente caso Físico")]
        public string CPF { get; set; }

        [Display(Name = "CNPJ do Cliente caso Jurídico")]
        public string CNPJ { get; set; }

        [Display(Name = "Nome do Cliente caso Físico")]
        public string cliNome { get; set; }

        [Display(Name = "Nome social do Cliente")]
        public string cliNomeSoc { get; set; }

        [Display(Name = "Representante caso Cliente Jurídico")]
        public string cliJurRep { get; set; }

        [Display(Name = "Data de nascimento do Cliente Físico")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CliFisNasc
        {
            get
            {
                return this.cliFisNasc.HasValue
                ? this.cliFisNasc.Value
               : DateTime.Now;
            }
            set
            {
                this.cliFisNasc = value;
            }
        }
        private DateTime? cliFisNasc = null;

        [Display(Name = "Telefone do Cliente")]
        public string cliTel { get; set; }

        [Display(Name = "Email do Cliente")]
        public string cliEmail { get; set; }

        [Display(Name = "Número de endereço do Cliente")]
        public int cliEndNum { get; set; }
    }
}