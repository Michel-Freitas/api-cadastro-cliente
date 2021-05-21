using MC.ApiCadastroClientes.Application.ViewModel;
using System;
using System.Collections.Generic;

namespace MC.ApiCadastroClientes.Application.Interfaces
{
    public interface IEnderecoAppService
    {
        NewEnderecoViewModel adicionar(NewEnderecoViewModel endereco, Guid clienteId);

        IEnumerable<ViewUpdateEnderecoViewModel> listarTodosEnderecos();

        ViewUpdateEnderecoViewModel atualizarEndereco(ViewUpdateEnderecoViewModel endereco);
    }
}
