using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpringLibrary.Models
{
    public class Estado
    {
        [Display(Name = "Unidade Federativa")]
        public string UF { get; set; }
    }
}