using MC.ApiCadastroClientes.Application.Interfaces;
using MC.ApiCadastroClientes.Application.ViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MC.ApiCadastroClientes.Services.WebApi.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[Controller]")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        private readonly IEnderecoAppService _enderecoAppService;

        public EnderecosController(IEnderecoAppService enderecoAppService)
        {
            _enderecoAppService = enderecoAppService;
        }

        [HttpPost("{clienteId:guid}")]
        public ActionResult<NewEnderecoViewModel> adicionarEndereco([FromBody] NewEnderecoViewModel endereco, Guid clienteId)
        {
            return _enderecoAppService.adicionar(endereco, clienteId);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ViewUpdateEnderecoViewModel>> listarTodosEnderecos()
        {
            return _enderecoAppService.listarTodosEnderecos().ToList();
        }

        [HttpPut("{id:guid}")]
        public ActionResult<ViewUpdateEnderecoViewModel> atualizarEndereco([FromBody] ViewUpdateEnderecoViewModel endereco, Guid id)
        {
            return _enderecoAppService.atualizarEndereco(endereco);
        }
    }
}
