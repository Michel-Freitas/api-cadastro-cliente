using DomainValidationCore.Validation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MC.ApiCadastroClientes.Services.WebApi.Controllers
{
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        private readonly ICollection<string> _errors = new List<string>();

        protected ActionResult ApiResponse(object result = null)
        {
            if (IsOperationValid())
                return Ok(result);

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                {"Messages", _errors.ToArray() }
            }));
        }

        protected ActionResult ApiResponse(ValidationResult validationResult)
        {
            var errors = validationResult.Errors;
            foreach (var error in errors)
            {
                AddError(error.Message);
            }

            return ApiResponse();
        }

        protected bool IsOperationValid()
        {
            return !_errors.Any();
        }

        protected void AddError(string erro)
        {
            _errors.Add(erro);
        }
    }
}
