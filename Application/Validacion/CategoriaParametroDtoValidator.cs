using Application.Dtos.Resquest;
using FluentValidation;

namespace Application.Validacion
{
    public class CategoriaParametroDtoValidator : AbstractValidator<CategoriaParametroDto>
    {
        public CategoriaParametroDtoValidator() 
        {
            RuleFor(c => c.Nombre)
                  .NotEmpty().WithMessage("El nombre de la Categoria es obligatorio.")
                  .MaximumLength(50).WithMessage("El nombre no debe exceder los 100 caracteres.");
        }
    }
}
