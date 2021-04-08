using financeiro.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace martloc.ApplicationCore.Entity
{
   public class Pessoa
    {
        public int Id { get; set; }
        public string NomeRazao { get; set; }
        public string Fone { get; set; }

        public string Endereco { get; set; }
        public int TipoPessoa { get; set; }
        
       public ICollection<Contato> Contatos { get; set; }

    }
}
