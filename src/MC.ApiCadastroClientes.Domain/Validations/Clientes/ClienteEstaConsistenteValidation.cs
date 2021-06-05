using DomainValidationCore.Validation;
using MC.ApiCadastroClientes.Domain.Models;
using MC.ApiCadastroClientes.Domain.Specifications.Clientes;

namespace MC.ApiCadastroClientes.Domain.Validations.Clientes
{
    public class ClienteEstaConsistenteValidation : Validator<Cliente>
    {
        public ClienteEstaConsistenteValidation()
        {
            var CpfCliente = new ClienteDeveTerCpfValidoSpecification();
            var EmailCliente = new ClienteDeveTerEmailValidoSpecification();
            var MaiorIdadeCliente = new ClienteDeveSerMaiorDeIdadeSpecification();

            base.Add("CpfCliente", new Rule<Cliente>(CpfCliente, "Cliente informou o CPF inválido."));
            base.Add("EmailCliente", new Rule<Cliente>(EmailCliente, "Cliente informou um e-mail inválido."));
            base.Add("MaiorIdadeCliente", new Rule<Cliente>(MaiorIdadeCliente, "Cliente não tem maioridade para cadastro."));
        }
    }
}
