using MC.ApiCadastroClientes.Domain.Models;
using System;

namespace MC.ApiCadastroClientes.Domain.Interfaces.Services
{
    public interface IClienteService : IDisposable
    {
        Cliente Adicionar(Cliente cliente);
        Cliente Atualizar(Cliente cliente);
        void Remover(Guid id);
    }
}
