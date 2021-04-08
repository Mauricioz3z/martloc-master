using martloc.ApplicationCore.Entity;
using martloc.ApplicationCore.Interfaces.Repository;
using martloc.ApplicationCore.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace martloc.ApplicationCore.Services
{


    public class UsuarioServices : ServiceBase<Usuario>, IUsuarioServices
    {
        protected readonly IRepository<Usuario> _usuarioReposotory;


        private UserManager<Usuario> _userMngr { get; }

        // var roleMngr = new RoleManager<IdentityRole>(roleStore);

   

        public UsuarioServices(IRepository<Usuario> Repository, UserManager<Usuario> UserMngr) : base(Repository)
        {
            _usuarioReposotory = Repository;
            _userMngr = UserMngr;

      
        }

        public async void addRole(Usuario u,string role)
        {
            var roles = await _userMngr.GetRolesAsync(u);
            await _userMngr.RemoveFromRolesAsync(u, roles.ToArray());
            await _userMngr.AddToRoleAsync(u, role);
        }

        public void addRole(Usuario u)
        {
            throw new NotImplementedException();
        }
    }
}
