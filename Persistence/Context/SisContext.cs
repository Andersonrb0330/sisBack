using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class SisContext : DbContext, ISisContext
    {
        public SisContext(DbContextOptions<SisContext> options) : base(options)
        { }

        public DbSet<Login> Logins { get; set; }

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
