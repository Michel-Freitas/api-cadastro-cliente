using DomainValidationCore.Validation;
using MC.ApiCadastroClientes.Domain.Interfaces;
using MC.ApiCadastroClientes.Domain.Models;
using MC.ApiCadastroClientes.Domain.Specifications.Clientes;

namespace MC.ApiCadastroClientes.Domain.Validations.Clientes
{
    public class ClienteAptoParaCadastroValidation : Validator<Cliente>
    {
        public ClienteAptoParaCadastroValidation(IClienteRepository clienteRepository)
        {
            var clienteUnico = new ClienteDevePossuirCpfEmailUnicoSpecification(clienteRepository);

            base.Add("ClienteUnico", new Rule<Cliente>(clienteUnico, "Cliente com CPF ou E-mail já cadastrado"));
        }
    }
}
