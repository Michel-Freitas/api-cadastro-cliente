using AutoMapper;
using MC.ApiCadastroClientes.Application.ViewModel;
using MC.ApiCadastroClientes.Domain.Models;

namespace MC.ApiCadastroClientes.Application.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();

            CreateMap<Cliente, NewClienteViewModel>().ReverseMap();
            CreateMap<Cliente, ViewUpdateClienteViewModel>().ReverseMap();
        }
    }
}
