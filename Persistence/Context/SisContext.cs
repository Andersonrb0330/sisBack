using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class SisContext : DbContext, ISisContext
    {
        public SisContext(DbContextOptions<SisContext> options) : base(options)
        { }

        public DbSet<Login> Logins { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Aula> Aulas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
