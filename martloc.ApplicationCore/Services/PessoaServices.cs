using martloc.ApplicationCore.Entity;
using martloc.ApplicationCore.Interfaces.Repository;
using martloc.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace martloc.ApplicationCore.Services
{
    public class PessoaServices : ServiceBase<Pessoa>, IPessoaServices
    {

        protected readonly IRepository<Pessoa> _pessoaReposotory;

        public PessoaServices(IRepository<Pessoa> Repository) : base(Repository)
        {
        }



          
    }
}
