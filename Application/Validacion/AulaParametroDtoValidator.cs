using Application.Dtos.Resquest;
using FluentValidation;

namespace Application.Validacion
{
    public class AulaParametroDtoValidator : AbstractValidator<AulaParametroDto>
    {
        public AulaParametroDtoValidator() 
        {
            RuleFor(a => a.Nombre)
              .NotEmpty().WithMessage("El nombre del Aula es obligatorio.")
              .MaximumLength(50).WithMessage("El nombre no debe exceder los 50 caracteres.");
        }
    }
}
