using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace martloc.UI.Web.Models
{
   public  class FisicaViewModel
    {
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Apelido { get; set; }

        public DateTime DataNascimento { get; set; }
    }
}
