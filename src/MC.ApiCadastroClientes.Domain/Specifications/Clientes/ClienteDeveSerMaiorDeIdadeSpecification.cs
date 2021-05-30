using DomainValidationCore.Interfaces.Specification;
using MC.ApiCadastroClientes.Domain.Models;
using System;

namespace MC.ApiCadastroClientes.Domain.Specifications.Clientes
{
    public class ClienteDeveSerMaiorDeIdadeSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return DateTime.Now.Year - cliente.DataNascimento.Year >= 18;
        }
    }
}
