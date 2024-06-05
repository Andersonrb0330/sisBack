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
        DbSet<Matricula>Matriculas { get; set; }
        DbSet<Curso> Cursos { get; set; }
        DbSet<MaestroDetalle> MaestroDetalles { get; set; }


        int SaveChanges();
    }
}
