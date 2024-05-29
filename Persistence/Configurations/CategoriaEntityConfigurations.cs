using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class CategoriaEntityConfigurations : IEntityTypeConfiguration<Categoria>
    {
        public CategoriaEntityConfigurations() { }

        void IEntityTypeConfiguration<Categoria>.Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(50)
                .IsRequired() // IsRequired por defecto es TRUE, este o no este  la palabra IsRequired
                .IsUnicode(false);
        }
    }
}
