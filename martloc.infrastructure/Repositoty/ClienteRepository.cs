using martloc.ApplicationCore.Entity;
using martloc.ApplicationCore.Interfaces.Repository;
using martloc.infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace financeiro.infrastructure.Repositoty
{
    public class ClienteRepository : Repository<Pessoa>,IClienteRepository
    {
        public ClienteRepository(BackendContext dbContext) : base(dbContext)
        {

        }

        public Pessoa ObterClientePorContato(int contatoId)
        {
            return Buscar(x => x.Contatos.Any(p => p.Id==contatoId)).FirstOrDefault();
        }
    }
}
