using Application.Dtos.Resquest;
using FluentValidation;

namespace Application.Validacion
{
    public class AlumnoParametroDtoValidator : AbstractValidator<AlumnoParametroDto>
    {
        public AlumnoParametroDtoValidator() 
        {
            RuleFor(a => a.Nombres)
               .NotEmpty().WithMessage("El nombre es obligatorio.")
               .Length(2, 50).WithMessage("El nombre debe tener entre 2 y 50 caracteres.");

            RuleFor(a => a.Apellidos)
                .NotEmpty().WithMessage("Los apellidos son obligatorios.")
                .Length(2, 50).WithMessage("Los apellidos deben tener entre 2 y 50 caracteres.");

            RuleFor(a => a.Telefono)
                .NotEmpty().WithMessage("El teléfono es obligatorio.")
                .Matches(@"^\d{9}$").WithMessage("El teléfono debe contener 9 dígitos numéricos.");

            RuleFor(a => a.Edad)
                .NotEmpty().WithMessage("La edad es obligatoria.")
                .InclusiveBetween(1, 99).WithMessage("La edad debe estar entre 1 y 99 años.");

            RuleFor(a => a.IdAula)
                .NotEmpty().WithMessage("El ID del aula es obligatorio.");

            RuleFor(a => a.IdCategoria)
                .NotEmpty().WithMessage("El ID de la categoría es obligatorio.");
        }
    }
}
