using MC.ApiCadastroClientes.Domain.Interfaces;
using MC.ApiCadastroClientes.Domain.Models;
using MC.ApiCadastroClientes.Infra.Data.Context;
using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MC.ApiCadastroClientes.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {

        public ClienteRepository(ApiCadastroClienteContext apicontext) : base(apicontext) { }
        
        public override Cliente ObterPorId(Guid id)
        {
            var sql = @"SELECT *
	                        FROM Clientes cl
	                        LEFT JOIN Enderecos ed
		                        ON cl.Id = ed.ClienteId
	                        WHERE cl.Id = @uid;";

            return Db.Database.GetDbConnection().Query<Cliente, Endereco, Cliente>(sql, (c, e) => 
                {
                    if(e != null)
                    {
                        c.Enderecos.Add(e);
                    }
                    return c;
                }, new { uid = id }).FirstOrDefault();
        }

        public IEnumerable<Cliente> BuscaDinamica(string fieldValue)
        {
            var sql = @"SELECT *
                        FROM Clientes
                        WHERE Nome LIKE @fieldvalue";

            return Db.Database.GetDbConnection().Query<Cliente>(sql, new { fieldvalue = fieldValue });
        }

        public IEnumerable<Cliente> ObterAtivos()
        {
            return Buscar(c => !c.Excluido);
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return Buscar(c => c.Cpf == cpf).FirstOrDefault();
        }

        public Cliente ObterPorEmail(string email)
        {
            return Buscar(c => c.Email == email).FirstOrDefault();
        }

        public override void Remover(Guid id)
        {
            var cliente = base.ObterPorId(id);
            cliente.Excluir();

            Atualizar(cliente);
        }
    }
}
