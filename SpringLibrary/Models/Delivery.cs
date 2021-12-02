using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpringLibrary.Models
{
    public class Delivery
    {
        [Display(Name = "Código do Delivery")]
        public int delCod { get; set; }

        [Display(Name = "Data de previsão de entrega")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DelDtPrevEntreg
        {
            get
            {
                return this.delDtPrevEntreg.HasValue
                ? this.delDtPrevEntreg.Value
               : DateTime.Now;
            }
            set
            {
                this.delDtPrevEntreg = value;
            }
        }
        private DateTime? delDtPrevEntreg = null;

        [Display(Name = "Data de saída")]
        public DateTime delDtSaida { get; set; }

        [Display(Name = "Data de chegada")]
        public DateTime delDtCheg { get; set; }

        [Display(Name = "Código da Nota Fiscal")]
        public int notaCod { get; set; }

        [Display(Name = "Código do Cliente")]
        public int cliCod { get; set; }
    }
}