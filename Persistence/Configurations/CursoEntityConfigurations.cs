using Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public class CursoEntityConfigurations : IEntityTypeConfiguration<Curso>
    {
        public CursoEntityConfigurations() { }

        void IEntityTypeConfiguration<Curso>.Configure(EntityTypeBuilder<Curso> builder)
        {

            // Table mapping
            builder.ToTable("Curso");

            // Primary key
            builder.HasKey(a => a.Id);

            // Properties
            builder.Property(a => a.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(a => a.Descripcion)
                .HasColumnName("Descripcion")
                .HasMaxLength(100)
                .IsUnicode(false);

        }
    }
}
