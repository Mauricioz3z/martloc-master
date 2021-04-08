using System;
using System.Collections.Generic;
using System.Text;

namespace martloc.ApplicationCore.Entity
{
    public class Juridica: Pessoa
    {
        public string Cnpj { get; set; }

        public string NomeFantasia { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string InscricaoEstadual { get; set; }
        public DateTime DataFundacao { get; set; }
    }
}
