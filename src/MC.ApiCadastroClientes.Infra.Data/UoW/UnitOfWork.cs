using MC.ApiCadastroClientes.Infra.Data.Context;

namespace MC.ApiCadastroClientes.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApiCadastroClienteContext _context;

        public UnitOfWork(ApiCadastroClienteContext context)
        {
            _context = context;
        }

        public void commit()
        {
            _context.SaveChanges();
        }
    }
}
