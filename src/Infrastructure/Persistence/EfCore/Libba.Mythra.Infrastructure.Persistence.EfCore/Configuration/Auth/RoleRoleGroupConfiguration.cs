using Libba.Mythra.Core.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libba.Mythra.Infrastructure.Persistence.EfCore.Configuration.Auth;

public class RoleRoleGroupConfiguration : BaseConfiguration<RoleRoleGroupEntity>
{
    public override void Configure(EntityTypeBuilder<RoleRoleGroupEntity> builder)
    {
        base.Configure(builder);

        builder.ToTable("AUTH_ROLE_ROLE_GROUP");

        builder.Property(rrg => rrg.RoleId).HasColumnName("AUTH_ROLE_ID");
        builder.Property(rrg => rrg.RoleGroupId).HasColumnName("AUTH_ROLE_GROUP_ID");


        builder.HasKey(rrg => new { rrg.RoleId, rrg.RoleGroupId });

        builder.HasOne(rrg => rrg.Role).WithMany(r => r.RoleRoleGroups).HasForeignKey(rrg => rrg.RoleId);
        builder.HasOne(rrg => rrg.RoleGroup).WithMany(rg => rg.RoleRoleGroups).HasForeignKey(rrg => rrg.RoleGroupId);

    }
}
