using Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public class MaestroDetalleEntityConfigurations : IEntityTypeConfiguration<MaestroDetalle>
    {
        public MaestroDetalleEntityConfigurations() { }

        void IEntityTypeConfiguration<MaestroDetalle>.Configure(EntityTypeBuilder<MaestroDetalle> builder)
        {
            // Table mapping
            builder.ToTable("MaestroDetalle");

            // Primary key
            builder.HasKey(a => a.Id);

            // Properties
            builder.Property(a => a.Acreditado)
                .HasColumnName("Acreditado")
                .HasMaxLength(1)
                .IsRequired();

            builder.Property(a => a.Estado)
                .HasColumnName("Estado")
                .HasMaxLength(50)
                .IsUnicode(false);

            // Relationships
            builder.HasOne(a => a.Matricula)
                .WithMany(a => a.MaestroDetalles) 
                .HasForeignKey(a => a.IdMatricula);

            builder.HasOne(a => a.Curso)
                .WithMany(a => a.MaestroDetalles) 
                .HasForeignKey(a => a.IdCurso);
        }
    }
}
