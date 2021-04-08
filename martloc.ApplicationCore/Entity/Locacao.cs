using martloc.ApplicationCore.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace martloc.ApplicationCore.Entity
{
   public class Locacao
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public string Descricao { get; set; }
        public DateTime DataContrato { get; set; }
        public virtual ICollection<LocacaoItens> LocacaoItens { get; set; }

        public Pessoa Pessoa { get; set; }

        //public virtual ICollection<LocacaoItens> LocacaoItens { get; set; }
    }
}
