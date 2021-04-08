
using martloc.ApplicationCore.Interfaces.Services;
using martloc.ApplicationCore.Entity;
using martloc.ApplicationCore.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace martloc.ApplicationCore.Services
{
    public class LocacaoServices : ServiceBase<Locacao>, ILocacaoServices
    { 
        //Regra de negocio aqui

        protected readonly ILocacaoRepository _clienteReposotory;

        public LocacaoServices(ILocacaoRepository Repository) : base(Repository)
        {
            _clienteReposotory = Repository;
        }

        public Pessoa ObterLocacoesInadimplente()
        {
           return _clienteReposotory.ObterLocacoesInadimplente();
        }





     
    }
}
