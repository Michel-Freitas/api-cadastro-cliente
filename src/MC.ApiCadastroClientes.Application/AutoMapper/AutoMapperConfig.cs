using AutoMapper;
using MC.ApiCadastroClientes.Application.ViewModel;
using MC.ApiCadastroClientes.Domain.Models;

namespace MC.ApiCadastroClientes.Application.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Cliente, ClienteEnderecoViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Endereco, ClienteEnderecoViewModel>().ReverseMap();
        }
    }
}
