using DomainValidationCore.Validation;
using System;

namespace MC.ApiCadastroClientes.Domain.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = new Guid();
        }

        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public abstract bool EhValido();
    }
}
