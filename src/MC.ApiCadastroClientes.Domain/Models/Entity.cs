using System;

namespace MC.ApiCadastroClientes.Domain.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = new Guid();
            DataCadastro = new DateTime();
        }

        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
