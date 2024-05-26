using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class LoginEntityConfigurations : IEntityTypeConfiguration<Login>
    {
        public LoginEntityConfigurations() { }

        void IEntityTypeConfiguration<Login>.Configure(EntityTypeBuilder<Login> builder)
        {
            builder.ToTable("Login");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Email)
                .HasColumnName("Email")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Password)
                .HasColumnName("Password")
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
