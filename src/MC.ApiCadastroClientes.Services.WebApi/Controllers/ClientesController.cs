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
            cliente = _clienteAppService.Adicionar(cliente);
            return cliente;
        }

        [HttpPut("{id:guid}")]
        public ActionResult<ViewUpdateClienteViewModel> atualizar(Guid id, [FromBody] ViewUpdateClienteViewModel cliente)
        {
            cliente = _clienteAppService.Atualizar(cliente);
            return cliente;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ViewUpdateClienteViewModel>> obterAtivos()
        {
            return _clienteAppService.ObterAtivos().ToList();
        }

        [HttpGet("{id:guid}")]
        public ActionResult<ViewUpdateClienteViewModel> obterPorId(Guid id)
        {
            return _clienteAppService.ObterPorId(id);
        }

        [HttpDelete("{idClient:guid}")]
        public void removerCliente(Guid idClient)
        {
            _clienteAppService.Remover(idClient);
        }

        [HttpGet("buscaGenerica")]
        public ActionResult<IEnumerable<ViewUpdateClienteViewModel>> buscaGenerica(string fieldvalue)
        {
            return _clienteAppService.BuscaDinamica(fieldvalue).ToList();
        }
    }
}
