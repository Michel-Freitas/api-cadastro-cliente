using MC.ApiCadastroClientes.Domain.Models;
using MC.ApiCadastroClientes.Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;

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
    }
}
