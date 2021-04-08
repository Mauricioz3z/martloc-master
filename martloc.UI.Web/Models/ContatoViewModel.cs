using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace martloc.UI.Web.Models
{
    public class ContatoViewModel
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Nome { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        public int PessoaId { get; set; }
        public PessoaViewModel Pessoa { get; set; }
    }
}
