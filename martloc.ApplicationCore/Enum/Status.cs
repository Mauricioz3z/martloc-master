using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace martloc.ApplicationCore.Enum
{
   public enum Status
    {
        [Display(Name = "Ativo")]
        Ativo =1 ,
        [Display(Name = "Inativo")]
        Inativo = 0,
       
    }
}
