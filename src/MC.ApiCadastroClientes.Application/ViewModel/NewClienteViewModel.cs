using System;
using System.ComponentModel.DataAnnotations;

namespace MC.ApiCadastroClientes.Application.ViewModel
{
    public class NewClienteViewModel
    {
        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(100, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo E-mail")]
        [MaxLength(100, ErrorMessage = "Máximo {1} caracteres")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha o campo CPF")]
        [MaxLength(11, ErrorMessage = "CPF deve ter {1} caracteres")]
        [MinLength(11, ErrorMessage = "CPF deve ter {1} caracteres")]
        public string Cpf { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataNascimento { get; set; }

        public bool Ativo { get; set; }

        public DomainValidationCore.Validation.ValidationResult ValidationResult { get; set; }
    }
}
