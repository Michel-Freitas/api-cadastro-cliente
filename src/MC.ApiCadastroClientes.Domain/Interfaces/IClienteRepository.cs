using MC.ApiCadastroClientes.Domain.Models;
using System.Collections.Generic;

namespace MC.ApiCadastroClientes.Domain.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Cliente ObterPorCpf(string cpf);

        Cliente ObterPorEmail(string email);

        IEnumerable<Cliente> BuscaDinamica(string fieldValue);

        IEnumerable<Cliente> ObterAtivos();
    }
}
