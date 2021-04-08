using martloc.ApplicationCore.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace martloc.UI.Web.Models
{
    public class LocacaoViewModel
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public string Descricao { get; set; }
        
        public DateTime DataContrato { get; set; }
        public virtual ICollection<LocacaoItensViewModel> LocacaoItens { get; set; }

        public PessoaViewModel Pessoa { get; set; }
    }
}
