using Challenge.Nubimetrics.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Challenge.Nubimetrics.Domain.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User");
            builder.HasKey(e => e.ID);
            builder.Property(e => e.Nombre).HasMaxLength(100).IsUnicode(false);
            builder.Property(e => e.Apellido).HasMaxLength(100).IsUnicode(false);
            builder.Property(e => e.Email).HasMaxLength(150).IsUnicode(true);
            builder.Property(e => e.Password).HasMaxLength(100).IsUnicode(true);
        }
    }
}
