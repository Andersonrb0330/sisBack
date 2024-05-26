using Application.Dtos.Resquest;
using FluentValidation;

namespace Application.Validacion
{
    public class LoginParametroDtoValidator : AbstractValidator<LoginParametroDto>
    {
        public LoginParametroDtoValidator() 
        {
            RuleFor(l => l.Email)
                   .NotEmpty().WithMessage("El email es obligatorio.")
                   .Length(10, 50).WithMessage("El email debe tener entre 10 y 50 caracteres.");

            RuleFor(l => l.Password)
                .NotEmpty().WithMessage("La clave es obligatorio.")
                .Length(5, 30).WithMessage("la clave debe tener entre 10 y 50 caracteres.");
        }
    }
}
