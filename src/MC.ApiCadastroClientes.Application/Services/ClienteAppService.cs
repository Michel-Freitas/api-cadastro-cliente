using AutoMapper;
using MC.ApiCadastroClientes.Application.Interfaces;
using MC.ApiCadastroClientes.Application.ViewModel;
using MC.ApiCadastroClientes.Domain.Interfaces;
using MC.ApiCadastroClientes.Domain.Models;
using System;
using System.Collections.Generic;

namespace MC.ApiCadastroClientes.Application.Services
{
    public class ClienteAppService : IClienteAppService
    {

        private readonly IClienteRepository _clienteRepository;
        private static IMapper _mapper;

        public ClienteAppService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public NewClienteViewModel Adicionar(NewClienteViewModel clienteModel)
        {
            var cliente = _mapper.Map<Cliente>(clienteModel);
            //var endereco = _mapper.Map<Endereco>(clienteEnderecoViewModel.Endereco);

            //cliente.Enderecos.Add(endereco);
            cliente.Ativo = true;

            _clienteRepository.Adicioner(cliente);
            return clienteModel;
        }

        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
            var cliente = _mapper.Map<Cliente>(clienteViewModel);
            cliente.Ativo = true;
            _clienteRepository.Atualizar(cliente);
            return clienteViewModel;
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
        }

        public IEnumerable<ViewClienteViewModel> ObterAtivos()
        {
            return _mapper.Map<IEnumerable<ViewClienteViewModel>>(_clienteRepository.ObterAtivos());
        }

        public ClienteViewModel ObterPorCpf(string cpf)
        {
            throw new NotImplementedException();
        }

        public ClienteViewModel ObterPorEmail(string email)
        {
            throw new NotImplementedException();
        }

        public ClienteViewModel ObterPorId(Guid id)
        {
            return _mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorId(id));
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(Guid id)
        {
            _clienteRepository.Remover(id);
        }
    }
}
