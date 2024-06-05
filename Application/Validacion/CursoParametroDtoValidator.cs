using Application.Dtos.Resquest;
using FluentValidation;

namespace Application.Validacion
{
    public class CursoParametroDtoValidator : AbstractValidator<CursoParametroDto>
    {
        public CursoParametroDtoValidator()
        {
            RuleFor(a => a.Nombre)
               .NotEmpty().WithMessage("El nombre es obligatorio.")
               .Length(2, 50).WithMessage("El nombre debe tener entre 2 y 50 caracteres.");

            RuleFor(a => a.Descripcion)
               .NotEmpty().WithMessage("La descripcion es obligatorio.")
               .Length(2, 50).WithMessage("La descripcion debe tener entre 2 y 50 caracteres.");
        }
    }
}
