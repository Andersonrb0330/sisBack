using Application.Dtos.Resquest;
using FluentValidation;

namespace Application.Validacion
{
    public class MaestroDetalleParametroDtoValidator : AbstractValidator<MaestroDetalleParametroDto>
    {
        public MaestroDetalleParametroDtoValidator()
        {
            RuleFor(c => c.IdMatricula)
                .GreaterThan(0).WithMessage("La matrícula es obligatoria y debe ser un número positivo.");

            RuleFor(c => c.IdCurso)
                .GreaterThan(0).WithMessage("El curso es obligatorio y debe ser un número positivo.");

            RuleFor(c => c.Acreditado)
                .GreaterThanOrEqualTo(0).WithMessage("La clave debe ser un número no negativo.");

            RuleFor(a => a.Estado)
               .NotEmpty().WithMessage("El estado es obligatorio.")
               .Length(2, 50).WithMessage("El estado debe tener entre 2 y 50 caracteres.");
        }
    }
}
