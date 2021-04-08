using financeiro.infrastructure.Repositoty;
using martloc.ApplicationCore.Entity;
using martloc.ApplicationCore.Interfaces.Repository;
using martloc.infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace martloc.infrastructure.Repositoty
{
   public class LocacaoRepository: Repository<Locacao>, ILocacaoRepository
    {
        public LocacaoRepository(BackendContext dbContext) : base(dbContext)
        {

        }

      

        public Pessoa ObterLocacoesInadimplente()
        {
            return Buscar(x => x.Pessoa.Id>0).Select(p=>p.Pessoa).FirstOrDefault();
        }
    }








}
