using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class AlumnoEntityConfigurations : IEntityTypeConfiguration<Alumno>
    {
        public AlumnoEntityConfigurations() { }

        void IEntityTypeConfiguration<Alumno>.Configure(EntityTypeBuilder<Alumno> builder)
        {

            // Table mapping
            builder.ToTable("Alumno");

            // Primary key
            builder.HasKey(a => a.Id);

            // Properties
            builder.Property(a => a.Nombres)
                .HasColumnName("Nombres")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(a => a.Apellidos)
                .HasColumnName("Apellidos")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(a => a.Telefono)
                .HasColumnName("Telefono")
                .HasMaxLength(15)
                .IsUnicode(false);

            builder.Property(a => a.Edad)
                .HasColumnName("Edad")
                .HasMaxLength(2)
                .IsRequired();

            // Relationships
            builder.HasOne(a => a.Aula)
                .WithMany(a => a.Alumnos) // Assuming Aula has a collection of Alumnos
                .HasForeignKey(a => a.IdAula);

            builder.HasOne(a => a.Categoria)
                .WithMany(a => a.Alumnos) // Assuming Aula has a collection of Alumnos
                .HasForeignKey(a => a.IdCategoria);
        }
    }
}
