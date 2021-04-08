using financeiro.infrastructure.Repositoty;
using martloc.ApplicationCore.Entity;
using martloc.infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace martloc.infrastructure.Repositoty
{
    public class MarcaRepository : Repository<Marca>
    {
        public MarcaRepository(BackendContext dbContext) : base(dbContext)
        {
        }
    }
}
