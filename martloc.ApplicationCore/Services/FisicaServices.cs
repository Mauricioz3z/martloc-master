using martloc.ApplicationCore.Entity;
using martloc.ApplicationCore.Interfaces.Repository;
using martloc.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace martloc.ApplicationCore.Services
{
    public class FisicaServices : ServiceBase<Fisica>, IFisicaServices
    {

        protected readonly IRepository<Fisica> _pessoaReposotory;

        public FisicaServices(IRepository<Fisica> Repository) : base(Repository)
        {
        }
    }
}
