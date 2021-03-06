using AutoMapper;
using MC.ApiCadastroClientes.Application.ViewModel;
using MC.ApiCadastroClientes.Domain.Models;

namespace MC.ApiCadastroClientes.Application.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Endereco, ViewUpdateEnderecoViewModel>().ReverseMap();

            CreateMap<Cliente, NewClienteViewModel>().ReverseMap();
            CreateMap<Cliente, ViewUpdateClienteViewModel>().ReverseMap();
            CreateMap<Endereco, NewEnderecoViewModel>().ReverseMap();
            CreateMap<Endereco, ViewUpdateEnderecoViewModel>().ReverseMap();
        }
    }
}
