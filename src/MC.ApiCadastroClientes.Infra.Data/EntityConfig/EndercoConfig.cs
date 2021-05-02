using MC.ApiCadastroClientes.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.ApiCadastroClientes.Infra.Data.EntityConfig
{
    class EndercoConfig : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Enderecos");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Logradouro)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(prop => prop.Numero)
                .IsRequired();

            builder.Property(prop => prop.Bairro)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(prop => prop.Cep)
                .IsRequired()
                .HasMaxLength(8)
                .IsFixedLength();

            builder.Property(prop => prop.Complemento)
                .HasMaxLength(150);

            // ONE TO MANY
            builder.HasOne(e => e.Cliente)
                .WithMany(c => c.Enderecos)
                .HasForeignKey(e => e.ClienteId);
        }
    }
}
