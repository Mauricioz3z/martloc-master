using martloc.ApplicationCore.Interfaces.Repository;
using martloc.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace martloc.ApplicationCore.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {

        protected readonly IRepository<T> _repository;
        public ServiceBase(IRepository<T> Repository)
        {
            _repository = Repository;
        }

        //public IEnumerable<T> List => throw new NotImplementedException();

        //public Cliente Adicionar(Cliente entity)
        //{
        //    return _clienteRepository.Adicionar(entity);
        //}

        //public void Atualizar(Cliente entity)
        //{
        //     _clienteRepository.Atualizar(entity);
        //}

        //public IEnumerable<Cliente> Buscar(Expression<Func<Cliente, bool>> predicado)
        //{
        //   return _clienteRepository.Buscar(predicado);
        //}

        //public Cliente ObterPorId(int Id)
        //{
        //    return _clienteRepository.ObterPorId(Id);
        //}

        //public IEnumerable<Cliente> ObterTodos()
        //{
        //    return _clienteRepository.ObterTodos();
        //}

        //public void Remover(Cliente entity)
        //{
        //    _clienteRepository.Remover(entity);
        //}
        public IQueryable<T> List => _repository.ObterTodos();

        public T Adicionar(T entity)
        {
            return _repository.Adicionar(entity);
        }

        public void Atualizar(T entity)
        {
            _repository.Atualizar(entity);
        }

        public IEnumerable<T> Buscar(Expression<Func<T, bool>> predicado)
        {
            return _repository.Buscar(predicado);
        }

        public T ObterPorId(int Id)
        {
            return _repository.ObterPorId(Id);
        }

        public void Remover(T entity)
        {
            _repository.Remover(entity);
        }
    }
}
