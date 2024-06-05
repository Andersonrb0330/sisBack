using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class MatriculaEntityConfigurations : IEntityTypeConfiguration<Matricula>
    {
        public MatriculaEntityConfigurations() { }
        void IEntityTypeConfiguration<Matricula>.Configure(EntityTypeBuilder<Matricula> builder)
        {
            // Table mapping
            builder.ToTable("Matricula");

            // Primary key
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Fecha)
                .HasColumnName("Fecha")
                .IsRequired()
                .HasColumnType("date");

            builder.Property(a => a.Estado)
                .HasColumnName("Estado")
                .HasMaxLength(50)
                .IsUnicode(false);

            // Relationships
            builder.HasOne(a => a.Login)
                .WithMany(a => a.Matriculas) 
                .HasForeignKey(a => a.IdLogin);

            // Relationships
            builder.HasOne(a => a.Alumno)
                .WithMany(a => a.Matriculas)
                .HasForeignKey(a => a.IdAlumno);

        }
    }
}
