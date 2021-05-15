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
            _clienteRepository.Adicioner(cliente);
            return clienteModel;
        }

        public ViewUpdateClienteViewModel Atualizar(ViewUpdateClienteViewModel clienteViewModel)
        {
            var cliente = _mapper.Map<Cliente>(clienteViewModel);
            _clienteRepository.Atualizar(cliente);
            return clienteViewModel;
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
        }

        public IEnumerable<ViewUpdateClienteViewModel> ObterAtivos()
        {
            return _mapper.Map<IEnumerable<ViewUpdateClienteViewModel>>(_clienteRepository.ObterAtivos());
        }

        public ViewUpdateClienteViewModel ObterPorCpf(string cpf)
        {
            throw new NotImplementedException();
        }

        public ViewUpdateClienteViewModel ObterPorEmail(string email)
        {
            throw new NotImplementedException();
        }

        public ViewUpdateClienteViewModel ObterPorId(Guid id)
        {
            return _mapper.Map<ViewUpdateClienteViewModel>(_clienteRepository.ObterPorId(id));
        }

        public IEnumerable<ViewUpdateClienteViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ViewUpdateClienteViewModel>>(_clienteRepository.ObterTodos());
        }

        public void Remover(Guid id)
        {
            _clienteRepository.Remover(id);
        }
    }
}
