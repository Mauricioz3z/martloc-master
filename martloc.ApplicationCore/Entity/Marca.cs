using martloc.ApplicationCore.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace martloc.ApplicationCore.Entity
{
   public class Marca
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public string Descricao { get; set; }
    }
}
