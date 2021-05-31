using MC.ApiCadastroClientes.Infra.Data.UoW;

namespace MC.ApiCadastroClientes.Application.Services
{
    public abstract class AppService
    {
        private readonly IUnitOfWork _uow;

        protected AppService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        protected void commit()
        {
            _uow.commit();
        }
    }
}
