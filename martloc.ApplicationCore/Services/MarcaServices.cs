using martloc.ApplicationCore.Entity;
using martloc.ApplicationCore.Interfaces.Repository;
using martloc.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace martloc.ApplicationCore.Services
{
    public class MarcaServices : ServiceBase<Marca>, IMarcaServices
    {

        protected readonly IRepository<Marca> _marcaReposotory;

        public MarcaServices(IRepository<Marca> Repository) : base(Repository)
        {
        }
    }
}
