
using martloc.ApplicationCore.Interfaces.Services;
using martloc.ApplicationCore.Entity;
using martloc.ApplicationCore.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace martloc.ApplicationCore.Services
{
    public class ClienteServices : ServiceBase<Pessoa>, IClienteServices
    { 
        //Regra de negocio aqui

        protected readonly IClienteRepository _clienteReposotory;

        public ClienteServices(IClienteRepository Repository) : base(Repository)
        {
            _clienteReposotory = Repository;
        }

        public Pessoa ObterClientePorContato(int contatoId)
        {
           return _clienteReposotory.ObterClientePorContato(contatoId);
        }





     
    }
}
