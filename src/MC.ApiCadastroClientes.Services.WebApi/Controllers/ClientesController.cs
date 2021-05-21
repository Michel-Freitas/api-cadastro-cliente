using MC.ApiCadastroClientes.Application.Interfaces;
using MC.ApiCadastroClientes.Application.ViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MC.ApiCadastroClientes.Services.WebApi.Controllers
{

    [EnableCors("MyPolicy")]
    [Route("api/[Controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [HttpPost]
        public ActionResult<NewClienteViewModel> adicionarCliente([FromBody] NewClienteViewModel cliente)
        {
            _clienteAppService.Adicionar(cliente);
            return cliente;
        }

        [HttpPut("{id:guid}")]
        public ActionResult<ViewUpdateClienteViewModel> atualizar(Guid id, [FromBody] ViewUpdateClienteViewModel cliente)
        {
            return _clienteAppService.Atualizar(cliente);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ViewUpdateClienteViewModel>> obterAtivos()
        {
            return _clienteAppService.ObterAtivos().ToList();
        }

        [HttpGet("{id:guid}")]
        public ActionResult<ViewUpdateClienteViewModel> obterPorId(string id)
        {
            Guid.TryParse(id, out Guid idGuid);
            return _clienteAppService.ObterPorId(idGuid);
        }

        [HttpDelete("{id:guid}")]
        public void removerCliente(string id)
        {
            Guid.TryParse(id, out Guid idGuid);
            _clienteAppService.Remover(idGuid);
        }
    }
}
