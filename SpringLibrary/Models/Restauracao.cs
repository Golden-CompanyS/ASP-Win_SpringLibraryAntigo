using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringLibrary.Models
{
    public class Restauracao
    {
        [Display(Name = "Código da Restauração")]
        public int restCod { get; set; }

        [Display(Name = "Descrição da Restauração")]
        public string restDesc { get; set; }

        [Display(Name = "Data de recebimento do livro para restauração")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RestDtRecebe
        {
            get
            {
                return this.restDtRecebe.HasValue
                ? this.restDtRecebe.Value
               : DateTime.Now;
            }
            set
            {
                this.restDtRecebe = value;
            }
        }
        private DateTime? restDtRecebe = null;

        [Display(Name = "Data inicial da restauração")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RestDtInicial
        {
            get
            {
                return this.restDtInicial.HasValue
                ? this.restDtInicial.Value
               : DateTime.Now;
            }
            set
            {
                this.restDtInicial = value;
            }
        }
        private DateTime? restDtInicial = null;

        [Display(Name = "Data data final prevista")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RestDtFinalPrev
        {
            get
            {
                return this.restDtFinalPrev.HasValue
                ? this.restDtFinalPrev.Value
               : DateTime.Now;
            }
            set
            {
                this.restDtFinalPrev = value;
            }
        }
        private DateTime? restDtFinalPrev = null;

        [Display(Name = "Preço da restauração")]
        [RegularExpression(@"R\$ ?\d{1,3}(\.\d{3})*,\d{2}", ErrorMessage = "Coloque um valor real")]
        public decimal restPreco { get; set; }

        [Display(Name = "Código do Cliente")]
        public int cliCod { get; set; }
    }
}
