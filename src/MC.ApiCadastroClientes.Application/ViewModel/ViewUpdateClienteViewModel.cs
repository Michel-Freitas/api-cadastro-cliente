using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MC.ApiCadastroClientes.Application.ViewModel
{
    public class ViewUpdateClienteViewModel : NewClienteViewModel
    {
        [Required(ErrorMessage = "Preencha o campo ID")]
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }

        public ICollection<ViewUpdateEnderecoViewModel> Enderecos { get; set;}
    }
}
