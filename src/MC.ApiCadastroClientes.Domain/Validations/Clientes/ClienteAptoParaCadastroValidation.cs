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
            var clienteCpfUnico = new ClienteDevePossuirCpfUnicoSpecification(clienteRepository);
            var clienteEmailUnico = new ClienteDevePossuirEmailUnicoSpecification(clienteRepository);

            base.Add("ClienteCpfunico", new Rule<Cliente>(clienteCpfUnico, "Cliente com CPF já cadastrado"));
            base.Add("ClienteEmailUnico", new Rule<Cliente>(clienteEmailUnico, "Cliente com E-mail já cadastrado"));
        }
    }
}
