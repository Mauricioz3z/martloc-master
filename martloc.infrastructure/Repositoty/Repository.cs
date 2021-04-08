using martloc.ApplicationCore.Interfaces.Repository;
using martloc.infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace financeiro.infrastructure.Repositoty
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly BackendContext _dbContext;

        public Repository(BackendContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TEntity Adicionar(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public void Atualizar(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified; 
            _dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicado)
        {
            return _dbContext.Set<TEntity>().Where(predicado).AsEnumerable();
        }

        public TEntity ObterPorId(int Id)
        {
            return _dbContext.Set<TEntity>().Find(Id);
        }

        public IQueryable<TEntity> ObterTodos()
        {
            return _dbContext.Set<TEntity>().AsQueryable();
        }

        public void Remover(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
