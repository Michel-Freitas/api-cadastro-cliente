using MC.ApiCadastroClientes.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.ApiCadastroClientes.Infra.Data.EntityConfig
{
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Nome)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(prop => prop.Cpf)
                .IsRequired()
                .HasMaxLength(11)
                .IsFixedLength();

            builder.Property(prop => prop.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(prop => prop.DataNascimento)
                .IsRequired();

            builder.Property(prop => prop.Ativo)
                .IsRequired();

            builder.Property(prop => prop.Excluido)
                .IsRequired();
        }
    }
}
