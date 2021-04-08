using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace martloc.UI.Web.Models
{
    public class JuridicaViewModel
    {
        public string Cnpj { get; set; }

        public string NomeFantasia { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string InscricaoEstadual { get; set; }
        public DateTime DataFundacao { get; set; }
    }
}
