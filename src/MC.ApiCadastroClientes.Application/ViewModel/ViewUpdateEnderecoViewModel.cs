using System;
using System.ComponentModel.DataAnnotations;

namespace MC.ApiCadastroClientes.Application.ViewModel
{
    public class ViewUpdateEnderecoViewModel : NewEnderecoViewModel
    {

        [Key]
        public Guid Id { get; set; }

        public DateTime DataCadastro { get; set; }

    }
}
