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
            var clienteCpfEmailUnico = new ClienteDevePossuirCpfEmailUnicoSpecification(clienteRepository);

            base.Add("ClienteUnico", new Rule<Cliente>(clienteCpfEmailUnico, "Cliente com CPF ou E-mail já cadastrado"));
        }
    }
}
