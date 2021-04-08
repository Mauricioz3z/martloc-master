using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace martloc.ApplicationCore.Interfaces.Repository
{
   public interface IRepository<TEntity>  where TEntity : class
    {
        TEntity Adicionar(TEntity entity);
        void Atualizar(TEntity entity);
        IQueryable<TEntity> ObterTodos();
        TEntity ObterPorId(int Id);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity,bool>> predicado);
        void Remover(TEntity entity);
    }
}
