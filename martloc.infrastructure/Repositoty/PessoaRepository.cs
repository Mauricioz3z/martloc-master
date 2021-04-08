using financeiro.infrastructure.Repositoty;
using martloc.ApplicationCore.Entity;
using martloc.infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace martloc.infrastructure.Repositoty
{
    public class PessoaRepository : Repository<Pessoa>
    {
        public PessoaRepository(BackendContext dbContext) : base(dbContext)
        {
        }
    }
}
