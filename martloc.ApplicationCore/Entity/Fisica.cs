using System;
using System.Collections.Generic;
using System.Text;

namespace martloc.ApplicationCore.Entity
{
    public class Fisica: Pessoa
    {
        public string Cpf { get; set; }
        public string Rg { get; set; }

        public string Apelido { get; set; }

        public DateTime DataNascimento { get; set; }
    }
}
