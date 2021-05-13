using MC.ApiCadastroClientes.Application.ViewModel;
using System;
using System.Collections.Generic;

namespace MC.ApiCadastroClientes.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        NewClienteViewModel Adicionar(NewClienteViewModel cliente);

        ViewUpdateClienteViewModel ObterPorId(Guid id);

        IEnumerable<ViewUpdateClienteViewModel> ObterTodos();

        IEnumerable<ViewUpdateClienteViewModel> ObterAtivos();

        ViewUpdateClienteViewModel ObterPorCpf(string cpf);

        ViewUpdateClienteViewModel ObterPorEmail(string email);

        ViewUpdateClienteViewModel Atualizar(ViewUpdateClienteViewModel clienteViewModel);

        void Remover(Guid id);
    }
}
