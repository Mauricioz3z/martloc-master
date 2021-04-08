using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace martloc.ApplicationCore.Entity
{
    public  class Equipamento
    {
        public int Id { get; set; }

        public int Status { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorQuinzenal { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorMensal { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorDiario { get; set; }
        public string Descricao { get; set; }
        public Categoria Categoria { get; set; }

        public Marca Marca { get; set; }
        public virtual ICollection<LocacaoItens> LocacaoItens { get; set; }
    }
}
