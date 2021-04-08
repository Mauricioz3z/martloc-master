using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace martloc.ApplicationCore.Interfaces.Services
{
   public interface IServiceBase<T>  where T : class
    {

        T Adicionar(T entity);
        void Atualizar(T entity);
        IQueryable<T> List { get; }
        
        T ObterPorId(int Id);
        IEnumerable<T> Buscar(Expression<Func<T, bool>> predicado);
        void Remover(T entity);
    }
}
