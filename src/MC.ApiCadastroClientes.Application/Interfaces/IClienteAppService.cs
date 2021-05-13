using MC.ApiCadastroClientes.Application.ViewModel;
using System;
using System.Collections.Generic;

namespace MC.ApiCadastroClientes.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        NewClienteViewModel Adicionar(NewClienteViewModel cliente);

        ClienteViewModel ObterPorId(Guid id);

        IEnumerable<ClienteViewModel> ObterTodos();

        IEnumerable<ViewClienteViewModel> ObterAtivos();

        ClienteViewModel ObterPorCpf(string cpf);

        ClienteViewModel ObterPorEmail(string email);

        ClienteViewModel Atualizar(ClienteViewModel clienteViewModel);

        void Remover(Guid id);
    }
}
