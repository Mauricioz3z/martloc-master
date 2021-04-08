using martloc.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace martloc.ApplicationCore.Interfaces.Services
{
   public interface IUsuarioServices :IServiceBase<Usuario>
    {


        public void addRole(Usuario u,string role);

    }
}
