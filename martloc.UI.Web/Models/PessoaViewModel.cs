using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace martloc.UI.Web.Models
{
    public class PessoaViewModel
    {
        public int Id { get; set; }

        public int TipoPessoa { get; set; }
        public string NomeRazao { get; set; }
        public string Fone { get; set; }

        public string Endereco { get; set; }

        //Juridica
        public string Cnpj { get; set; }

        public string NomeFantasia { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string InscricaoEstadual { get; set; }
        public DateTime DataFundacao { get; set; }
        //

        //Fisica
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Apelido { get; set; }

        public DateTime DataNascimento { get; set; }
        //

        public ICollection<ContatoViewModel> Contatos { get; set; }
    }
}
