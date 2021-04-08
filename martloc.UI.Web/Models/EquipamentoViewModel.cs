using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace martloc.UI.Web.Models
{
    public class EquipamentoViewModel
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
        public CategoriaViewModel Categoria { get; set; }

        public MarcaViewModel Marca { get; set; }
        public virtual ICollection<LocacaoItensViewModel> LocacaoItens { get; set; }
    }
}
