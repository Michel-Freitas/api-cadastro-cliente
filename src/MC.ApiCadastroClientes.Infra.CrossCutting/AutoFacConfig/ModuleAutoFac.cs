using Autofac;

namespace MC.ApiCadastroClientes.Infra.CrossCutting.AutoFacConfig
{
    public class ModuleAutoFac : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            AutoFacConfig.Load(builder);
        }
    }
}
