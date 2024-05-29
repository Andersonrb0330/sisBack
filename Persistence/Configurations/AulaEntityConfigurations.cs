using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class AulaEntityConfigurations : IEntityTypeConfiguration<Aula>
    {
        public AulaEntityConfigurations() { }

        void IEntityTypeConfiguration<Aula>.Configure(EntityTypeBuilder<Aula> builder)
        {
            builder.ToTable("Aula");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(50)
                .IsRequired() // IsRequired por defecto es TRUE, este o no este  la palabra IsRequired
                .IsUnicode(false);
        }
    }
}
