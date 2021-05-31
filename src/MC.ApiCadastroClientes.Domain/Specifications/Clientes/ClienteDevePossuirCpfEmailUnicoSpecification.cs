using DomainValidationCore.Interfaces.Specification;
using MC.ApiCadastroClientes.Domain.Interfaces;
using MC.ApiCadastroClientes.Domain.Models;

namespace MC.ApiCadastroClientes.Domain.Specifications.Clientes
{
    public class ClienteDevePossuirCpfEmailUnicoSpecification : ISpecification<Cliente>
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteDevePossuirCpfEmailUnicoSpecification(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public bool IsSatisfiedBy(Cliente cliente)
        {
            return _clienteRepository.ObterPorCpf(cliente.Cpf) == null &&
                _clienteRepository.ObterPorEmail(cliente.Email) == null;
        }
    }
}
