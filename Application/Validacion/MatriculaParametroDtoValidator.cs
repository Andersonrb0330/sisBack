using Application.Dtos.Resquest;
using FluentValidation;

namespace Application.Validacion
{
    public class MatriculaParametroDtoValidator : AbstractValidator<MatriculaParametroDto>
    {
        public MatriculaParametroDtoValidator()
        {
            RuleFor(m => m.Fecha)
                 .NotEmpty().WithMessage("La fecha es obligatoria.");

            RuleFor(m => m.Estado)
                .NotEmpty().WithMessage("El estado es obligatorio.")
                .Length(2, 50).WithMessage("El estado debe tener entre 2 y 50 caracteres.");

            RuleFor(m => m.IdAlumno)
                .GreaterThan(0).WithMessage("El Id del alumno es obligatorio y debe ser un número positivo.");

            RuleFor(m => m.IdLogin)
                .GreaterThan(0).WithMessage("El Id del login es obligatorio y debe ser un número positivo.");
        }
    }
}
