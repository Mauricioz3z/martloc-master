using martloc.ApplicationCore.Entity;
using martloc.ApplicationCore.Interfaces.Repository;
using martloc.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace martloc.ApplicationCore.Services
{
    public class JuridicaServices : ServiceBase<Juridica>, IJuridicaServices
    {

        protected readonly IRepository<Juridica> _pessoaReposotory;

        public JuridicaServices(IRepository<Juridica> Repository) : base(Repository)
        {
        }
    }
}
