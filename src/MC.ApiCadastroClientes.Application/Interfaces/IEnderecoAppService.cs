using MC.ApiCadastroClientes.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.ApiCadastroClientes.Application.Interfaces
{
    public interface IEnderecoAppService
    {
        NewEnderecoViewModel adicionar(NewEnderecoViewModel endereco, Guid clienteId);

        IEnumerable<ViewUpdateEnderecoViewModel> listarTodosEnderecos();
    }
}
