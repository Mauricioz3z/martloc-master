using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace martloc.ApplicationCore.Entity
{
  public  class LocacaoItens
    {
        public int LocacaoId { get; set; }
        public int EquipamentoId { get; set; }
        public int Quantidade { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Valor { get; set; }

        public Locacao Locacao { get; set; }

        public Equipamento Equipamento { get; set; }


    }
}
