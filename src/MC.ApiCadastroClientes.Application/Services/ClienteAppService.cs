using AutoMapper;
using MC.ApiCadastroClientes.Application.Interfaces;
using MC.ApiCadastroClientes.Application.ViewModel;
using MC.ApiCadastroClientes.Domain.Interfaces;
using MC.ApiCadastroClientes.Domain.Interfaces.Services;
using MC.ApiCadastroClientes.Domain.Models;
using MC.ApiCadastroClientes.Infra.Data.UoW;
using System;
using System.Collections.Generic;

namespace MC.ApiCadastroClientes.Application.Services
{
    public class ClienteAppService : AppService, IClienteAppService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteService _clienteService;
        private static IMapper _mapper;

        public ClienteAppService(IClienteRepository clienteRepository,
            IClienteService clienteService,
            IUnitOfWork uow,
            IMapper mapper) : base (uow)
        {
            _clienteRepository = clienteRepository;
            _clienteService = clienteService;
            _mapper = mapper;
        }

        public NewClienteViewModel Adicionar(NewClienteViewModel clienteModel)
        {
            var cliente = _mapper.Map<Cliente>(clienteModel);
            var clienteResult = _clienteService.Adicionar(cliente);

            if (clienteResult.ValidationResult.IsValid)
                commit();

            clienteModel = _mapper.Map<NewClienteViewModel>(clienteResult);
            return clienteModel;
        }

        public ViewUpdateClienteViewModel Atualizar(ViewUpdateClienteViewModel clienteViewModel)
        {
            var cliente = _mapper.Map<Cliente>(clienteViewModel);
            var clienteResult = _clienteService.Atualizar(cliente);
            if(clienteResult.ValidationResult.IsValid)
                commit();

            clienteViewModel = _mapper.Map<ViewUpdateClienteViewModel>(clienteResult);

            return clienteViewModel;
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

        public IEnumerable<ViewUpdateClienteViewModel> BuscaDinamica(string fieldValue)
        {
            return _mapper.Map<IEnumerable<ViewUpdateClienteViewModel>>(_clienteRepository.BuscaDinamica(fieldValue));
        }

        public void Remover(Guid id)
        {
            _clienteService.Remover(id);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
            _clienteService.Dispose();
        }
    }
}
