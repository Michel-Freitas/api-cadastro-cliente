﻿using MC.ApiCadastroClientes.Application.Interfaces;
using MC.ApiCadastroClientes.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MC.ApiCadastroClientes.Services.WebApi.Controllers
{
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
        public ActionResult<ClienteEnderecoViewModel> adicionarCliente([FromBody] ClienteEnderecoViewModel clienteEndereco)
        {
            _clienteAppService.Adicionar(clienteEndereco);
            return clienteEndereco;
        }

        [HttpPut("{id}")]
        public ActionResult<ClienteViewModel> atualizar(Guid id, [FromBody] ClienteViewModel cliente)
        {
            return _clienteAppService.Atualizar(cliente);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ClienteViewModel>> obterAtivos()
        {
            return _clienteAppService.ObterAtivos().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<ClienteViewModel> obterPorId(Guid id)
        {
            return _clienteAppService.ObterPorId(id);
        }

        [HttpDelete("{id}")]
        public void remover(Guid id)
        {
            _clienteAppService.Remover(id);
        }
    }
}
