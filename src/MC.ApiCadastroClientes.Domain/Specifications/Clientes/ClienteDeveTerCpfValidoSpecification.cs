using DomainValidationCore.Interfaces.Specification;
using MC.ApiCadastroClientes.Domain.Models;
using MC.ApiCadastroClientes.Domain.ValueObjects;

namespace MC.ApiCadastroClientes.Domain.Specifications.Clientes
{
    public class ClienteDeveTerCpfValidoSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return Cpf.Validar(cliente.Cpf);
        }
    }
}
