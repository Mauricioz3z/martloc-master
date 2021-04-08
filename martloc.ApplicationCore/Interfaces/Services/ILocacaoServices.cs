using martloc.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace martloc.ApplicationCore.Interfaces.Services
{
   public interface ILocacaoServices :IServiceBase<Locacao>
    {

        Pessoa ObterLocacoesInadimplente();
        

    }
}
