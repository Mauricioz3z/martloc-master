using martloc.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace martloc.ApplicationCore.Entity
{
    public class Contato
    {
        public Contato()
        {

        }

        public int Id { get; set; }
        [MaxLength(100)]
        public string Nome { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }


    }
}
