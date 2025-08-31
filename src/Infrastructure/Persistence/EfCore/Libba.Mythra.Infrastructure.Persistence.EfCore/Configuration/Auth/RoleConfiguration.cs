using Libba.Mythra.Core.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libba.Mythra.Infrastructure.Persistence.EfCore.Configuration.Auth;

public class RoleConfiguration : BaseConfiguration<RoleEntity>
{
    public override void Configure(EntityTypeBuilder<RoleEntity> builder)
    {
        base.Configure(builder);

        builder.ToTable("AUTH_ROLE");

        builder.Property(r => r.Name).HasColumnName("NAME").IsRequired().HasMaxLength(50);

        builder.Property(r => r.Description).HasColumnName("DESCRIPTION").IsRequired(false).HasMaxLength(255);


        builder.HasMany(r => r.EndpointRoles).WithOne(er => er.Role).HasForeignKey(er => er.RoleId);

        builder.HasMany(r => r.RoleRoleGroups).WithOne(rrg => rrg.Role).HasForeignKey(rrg => rrg.RoleId);
    }
}
