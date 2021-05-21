using MC.ApiCadastroClientes.Domain.Models;
using System.Collections.Generic;

namespace MC.ApiCadastroClientes.Domain.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        public IEnumerable<Endereco> ObterPorEstado();
        public IEnumerable<Endereco> ObterPorCidade();
        public IEnumerable<Endereco> ObterPorBairro();
        public IEnumerable<Endereco> ObterPorLogradouro();
    }
}
