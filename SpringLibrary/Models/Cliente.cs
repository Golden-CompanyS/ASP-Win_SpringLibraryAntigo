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
        [Range(1, 8, ErrorMessage = "O código deve ter de 1 a 8 dígitos")]
        public int cliCod { get; set; }

        [Display(Name = "CPF do Cliente caso Físico")]
        [RegularExpression(@"[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}", ErrorMessage = "Valor Inválido")]
        public string CPF { get; set; }

        [Display(Name = "CNPJ do Cliente caso Jurídico")]
        [RegularExpression(@"^\d{3}.?\d{3}.?\d{3}/?\d{3}-?\d{2}$ ou ^\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}$", ErrorMessage = "Valor inválido")]
        public string CNPJ { get; set; }

        [Display(Name = "Nome do Cliente caso Físico")]
        [Required(ErrorMessage = "O nome é obrigatório")]
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
        [RegularExpression(@"^\([1-9]{2}\) [9]{0,1}[6-9]{1}[0-9]{3}\-[0-9]{4}$", ErrorMessage = "Formato de telefone inválido")]
        public string cliTel { get; set; }

        [Display(Name = "Email do Cliente")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Formato de e-mail inválido")]
        public string cliEmail { get; set; }

        [Display(Name = "Logadouro do endereço")]
        public string lograd { get; set; }

        [Display(Name = "Número de endereço do Cliente")]
        [Required(ErrorMessage = "O número é obrigatório")]
        public int cliEndNum { get; set; }

        [Display(Name = "Nome da Cidade")]
        public string cidNome { get; set; }

        [Display(Name = "Unidade Federativa")]
        public string UF { get; set; }

        [Display(Name = "CEP do endereço")]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "Digite um CEP válido")]
        public string CEP { get; set; }

    }
}