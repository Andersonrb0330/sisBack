using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;

namespace Persistence.Extensions
{
        public static class ServiceCollectionsExtensions
        {
            public static void AddPersistenceProject(this IServiceCollection services, IConfiguration configuration)
            {
                services.AddDbContext<SisContext>(
                    options => options.UseSqlServer(configuration.GetConnectionString("SqlSis"),
                    builder => builder.MigrationsAssembly(typeof(SisContext).Assembly.FullName)));
                services.AddScoped<ISisContext>(provider => provider.GetService<SisContext>());
                services.AddRepositories();
        }
            public static void AddRepositories(this IServiceCollection services)
            {
                services.AddTransient<ILoginRepository, LoginRepository>();
                services.AddTransient<IAlumnoRepository, AlumnoRepository>();
                services.AddTransient<IAulaRepository, AulaRepository>();
                services.AddTransient<ICategoriaRepository, CategoriaRepository>();
                services.AddTransient<IUnitOfWork, UnitOfWork>();
            }
        }
}
