using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace martloc.UI.Web.Models
{
    public class LocacaoItensViewModel
    {
        public int LocacaoId { get; set; }
        public int EquipamentoId { get; set; }

        public LocacaoViewModel Locacao { get; set; }

        public EquipamentoViewModel Equipamento { get; set; }
    }
}
