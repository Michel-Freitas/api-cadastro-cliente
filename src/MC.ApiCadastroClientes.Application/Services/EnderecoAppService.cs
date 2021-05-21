using AutoMapper;
using MC.ApiCadastroClientes.Application.Interfaces;
using MC.ApiCadastroClientes.Application.ViewModel;
using MC.ApiCadastroClientes.Domain.Interfaces;
using MC.ApiCadastroClientes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.ApiCadastroClientes.Application.Services
{
    public class EnderecoAppService : IEnderecoAppService
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private static IMapper _mapper;

        public EnderecoAppService(IEnderecoRepository enderecoRepository, IMapper mapper)
        {
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
        }

        public NewEnderecoViewModel adicionar(NewEnderecoViewModel enderecoModel, Guid clienteId)
        {
            var endereco = _mapper.Map<Endereco>(enderecoModel);
            _enderecoRepository.Adicioner(endereco);

            return enderecoModel;
        }

        public IEnumerable<ViewUpdateEnderecoViewModel> listarTodosEnderecos()
        {
            return _mapper.Map<IEnumerable<ViewUpdateEnderecoViewModel>>(_enderecoRepository.ObterTodos());
        }

        public ViewUpdateEnderecoViewModel atualizarEndereco(ViewUpdateEnderecoViewModel enderecoModel)
        {
            var endereco = _mapper.Map<Endereco>(enderecoModel);
            _enderecoRepository.Atualizar(endereco);
            return enderecoModel;
        }
    }
}
