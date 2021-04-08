
using martloc.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace martloc.ApplicationCore.Interfaces.Repository
{
   public interface  IClienteRepository:IRepository<Pessoa>
    {
        Pessoa ObterClientePorContato(int contatoId);
    }
}
