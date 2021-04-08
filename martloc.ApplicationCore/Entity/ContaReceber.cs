using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace martloc.ApplicationCore.Entity
{
   public class ContaReceber
    {
        public int Id { get; set; }
        public DateTime DataMaxPagamento { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Valor { get; set; }

        public int Quitado { get; set; }

        public int LocacaoId { get; set; }
        public Locacao Locacao { get; set; }



    }
}
