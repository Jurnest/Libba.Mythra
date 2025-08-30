using Libba.Mythra.Core.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libba.Mythra.Infrastructure.Persistence.EfCore.Configuration.Auth;

public class UserConfiguration : BaseConfiguration<UserEntity>
{
    public override void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        base.Configure(builder);

        builder.ToTable("AUTH_USER");

        builder.Property(u => u.Name).HasColumnName("NAME").IsRequired().HasMaxLength(50);
        builder.Property(u => u.Surname).HasColumnName("SURNAME").IsRequired().HasMaxLength(50);
        builder.Property(u => u.Email).HasColumnName("EMAIL").IsRequired().HasMaxLength(100);
        builder.Property(u => u.Password).HasColumnName("PASSWORD").IsRequired();
        builder.Property(u => u.IsActive).HasColumnName("IS_ACTIVE").IsRequired();
    }
}
