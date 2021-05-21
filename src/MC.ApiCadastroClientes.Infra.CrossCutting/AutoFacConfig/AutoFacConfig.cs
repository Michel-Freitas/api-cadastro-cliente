using Autofac;
using AutoMapper;
using MC.ApiCadastroClientes.Application.AutoMapper;
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
            builder.RegisterType<EnderecoAppService>().As<IEnderecoAppService>();
            builder.RegisterType<EnderecoRepository>().As<IEnderecoRepository>();

            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperConfig());
            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();

            #endregion
        }
    }
}
