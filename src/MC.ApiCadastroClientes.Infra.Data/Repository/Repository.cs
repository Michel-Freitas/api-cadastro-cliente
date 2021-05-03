using MC.ApiCadastroClientes.Domain.Interfaces;
using MC.ApiCadastroClientes.Domain.Models;
using MC.ApiCadastroClientes.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MC.ApiCadastroClientes.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly ApiCadastroClienteContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(ApiCadastroClienteContext apiContext)
        {
            Db = apiContext;
            DbSet = Db.Set<TEntity>();
        }

        public TEntity Adicioner(TEntity obj)
        {
            var resultEntity = DbSet.Add(obj);
            SaveChanges();
            return resultEntity.Entity;
        }

        public TEntity Atualizar(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
            SaveChanges();
            return obj;
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public IEnumerable<TEntity> ObterTodosPaginados(int s, int t)
        {
            return DbSet.Skip(s).Take(t).ToList();
        }

        public void Remover(Guid id)
        {
            var obj = new TEntity() { Id = id };
            DbSet.Remove(obj);
            SaveChanges();
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
    }
}