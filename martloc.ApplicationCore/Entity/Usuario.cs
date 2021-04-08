
using Microsoft.AspNetCore.Identity;

namespace martloc.ApplicationCore.Entity
{
    public class Usuario:IdentityUser
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

    }
}
