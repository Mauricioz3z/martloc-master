using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace martloc.UI.Web.Models
{
    public class PerfilViewModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }

        public List<string> Claims { get; set; }

    }
}
