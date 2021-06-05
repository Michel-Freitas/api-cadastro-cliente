using DomainValidationCore.Validation;
using MC.ApiCadastroClientes.Domain.Interfaces;
using MC.ApiCadastroClientes.Domain.Models;
using MC.ApiCadastroClientes.Domain.Specifications.Clientes;

namespace MC.ApiCadastroClientes.Domain.Validations.Clientes
{
    class ClienteAptoParaAtualizacaoValidation : Validator<Cliente>
    {
        public ClienteAptoParaAtualizacaoValidation(IClienteRepository clienteRepository)
        {
            var clienteCadastrado = new ClienteDeveTerIdCadastradoSpecification(clienteRepository);

            base.Add("ClienteCadastrado", new Rule<Cliente>(clienteCadastrado, "Não existe cliente cadastrado com esse ID"));
        }
    }
}
