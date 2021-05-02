using MC.ApiCadastroClientes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MC.ApiCadastroClientes.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        TEntity Adicioner(TEntity obj);

        TEntity ObterPorId(Guid id);

        IEnumerable<TEntity> ObterTodos();

        IEnumerable<TEntity> ObterTodosPaginados(int s, int t);

        TEntity Atualizar(TEntity obj);

        void Remover(Guid id);

        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);

        int SaveChanges();
    }
}
