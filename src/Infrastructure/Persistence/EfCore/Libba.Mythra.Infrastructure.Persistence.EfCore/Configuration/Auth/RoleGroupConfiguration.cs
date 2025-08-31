using Libba.Mythra.Core.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libba.Mythra.Infrastructure.Persistence.EfCore.Configuration.Auth;

public class RoleGroupConfiguration : BaseConfiguration<RoleGroupEntity>
{
    public override void Configure(EntityTypeBuilder<RoleGroupEntity> builder)
    {
        base.Configure(builder);


        builder.ToTable("AUTH_ROLE_GROUP");

        builder.Property(r => r.Name).HasColumnName("NAME").IsRequired().HasMaxLength(50);
        builder.Property(r => r.Description).HasColumnName("DESCRIPTION").IsRequired(false).HasMaxLength(255);

        builder.HasMany(rg => rg.RoleRoleGroups).WithOne(rrg => rrg.RoleGroup).HasForeignKey(rrg => rrg.RoleGroupId);
        builder.HasMany(rg => rg.UserRoleGroups).WithOne(urg => urg.RoleGroup).HasForeignKey(urg => urg.RoleGroupId);
    }
}
