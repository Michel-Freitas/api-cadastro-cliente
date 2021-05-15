using MC.ApiCadastroClientes.Domain.Models;
using MC.ApiCadastroClientes.Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace MC.ApiCadastroClientes.Infra.Data.Context
{
    public class ApiCadastroClienteContext : DbContext
    {
        public ApiCadastroClienteContext()
        {

        }
        public ApiCadastroClienteContext(DbContextOptions<ApiCadastroClienteContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>(new ClienteConfig().Configure);

            modelBuilder.Entity<Endereco>(new EndercoConfig().Configure);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if(entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if(entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChanges();
        }
    }
}
