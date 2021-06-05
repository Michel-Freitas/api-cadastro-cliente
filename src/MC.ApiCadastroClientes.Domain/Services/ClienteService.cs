using MC.ApiCadastroClientes.Domain.Interfaces;
using MC.ApiCadastroClientes.Domain.Interfaces.Services;
using MC.ApiCadastroClientes.Domain.Models;
using MC.ApiCadastroClientes.Domain.Validations.Clientes;
using System;

namespace MC.ApiCadastroClientes.Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Cliente Adicionar(Cliente cliente)
        {
            if (!cliente.EhValido())
                return cliente;

            cliente.ValidationResult = new ClienteAptoParaCadastroValidation(_clienteRepository).Validate(cliente);

            return !cliente.ValidationResult.IsValid ? cliente : _clienteRepository.Adicionar(cliente);
        }

        public Cliente Atualizar(Cliente cliente)
        {
            if (!cliente.EhValido())
                return cliente;

            cliente.ValidationResult = new ClienteAptoParaAtualizacaoValidation(_clienteRepository).Validate(cliente);

            return _clienteRepository.Atualizar(cliente);
        }

        public void Remover(Guid id)
        {
            _clienteRepository.Remover(id);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
        }
    }
}
