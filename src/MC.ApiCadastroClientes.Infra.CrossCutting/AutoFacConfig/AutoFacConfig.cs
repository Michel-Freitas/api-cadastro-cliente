using Autofac;
using MC.ApiCadastroClientes.Application.Interfaces;
using MC.ApiCadastroClientes.Application.Services;
using MC.ApiCadastroClientes.Domain.Interfaces;
using MC.ApiCadastroClientes.Infra.Data.Repository;

namespace MC.ApiCadastroClientes.Infra.CrossCutting.AutoFacConfig
{
    public class AutoFacConfig
    {
        public static void Load(ContainerBuilder builder)
        {
            #region AutoFac

            builder.RegisterType<ClienteAppService>().As<IClienteAppService>();
            builder.RegisterType<ClienteRepository>().As<IClienteRepository>();

            #endregion
        }
    }
}
