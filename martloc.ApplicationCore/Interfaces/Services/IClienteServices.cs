using martloc.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace martloc.ApplicationCore.Interfaces.Services
{
  public  interface IClienteServices : IServiceBase<Pessoa>    {
        //da pra melhorar essa classe trabalhando com  dados gernericos
        Pessoa ObterClientePorContato(int contatoId);


    }
}
