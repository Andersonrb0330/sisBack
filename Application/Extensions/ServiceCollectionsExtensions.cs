using Application.Dtos.Resquest;
using Application.Implementaciones;
using Application.Interfaces;
using Application.Validacion;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        public static void AddApplicationProject(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<ISeguridadService, SeguridadService>();
            services.AddTransient<IAlumnoService, AlumnoService>();
            services.AddTransient<IAulaService, AulaService>();
            services.AddTransient<ICategoriaService, CategoriaService>();

            // Aquì damos a enteder que van a trabajar juntos las VALIDACIONES
            services.AddControllersWithViews().AddFluentValidation();

            services.AddTransient<IValidator<LoginParametroDto>, LoginParametroDtoValidator>();
            services.AddTransient<IValidator<AlumnoParametroDto>, AlumnoParametroDtoValidator>();
            services.AddTransient<IValidator<AulaParametroDto>, AulaParametroDtoValidator>();
            services.AddTransient<IValidator<CategoriaParametroDto>, CategoriaParametroDtoValidator>();
        }
    }
}
