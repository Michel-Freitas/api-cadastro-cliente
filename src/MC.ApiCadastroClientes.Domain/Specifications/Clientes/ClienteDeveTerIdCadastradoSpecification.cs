using DomainValidationCore.Interfaces.Specification;
using MC.ApiCadastroClientes.Domain.Interfaces;
using MC.ApiCadastroClientes.Domain.Models;

namespace MC.ApiCadastroClientes.Domain.Specifications.Clientes
{
    class ClienteDeveTerIdCadastradoSpecification : ISpecification<Cliente>
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteDeveTerIdCadastradoSpecification(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public bool IsSatisfiedBy(Cliente cliente)
        {
            return _clienteRepository.ObterPorId(cliente.Id) != null;
        }
    }
}
