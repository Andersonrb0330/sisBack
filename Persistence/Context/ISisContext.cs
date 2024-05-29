using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public interface ISisContext
    {
        DbSet<Login> Logins { get; set; }
        DbSet<Alumno> Alumnos { get; set; }
        DbSet<Aula> Aulas { get; set; }
        DbSet<Categoria> Categorias { get; set; }
        int SaveChanges();
    }
}
