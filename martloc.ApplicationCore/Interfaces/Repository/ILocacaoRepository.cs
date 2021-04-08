
using martloc.ApplicationCore.Entity;
namespace martloc.ApplicationCore.Interfaces.Repository
{
   public interface ILocacaoRepository : IRepository<Locacao>
    {
        Pessoa ObterLocacoesInadimplente();
    }
}
