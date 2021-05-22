using MC.ApiCadastroClientes.Domain.Interfaces;
using MC.ApiCadastroClientes.Domain.Models;
using MC.ApiCadastroClientes.Infra.Data.Context;
using System;
using System.Collections.Generic;

namespace MC.ApiCadastroClientes.Infra.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {

        private readonly ApiCadastroClienteContext _apiContext;

        public EnderecoRepository(ApiCadastroClienteContext apicontext) : base(apicontext)
        {
            _apiContext = apicontext;
        }

        public IEnumerable<Endereco> ObterPorBairro()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Endereco> ObterPorCidade()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Endereco> ObterPorEstado()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Endereco> ObterPorLogradouro()
        {
            throw new NotImplementedException();
        }
    }
}
