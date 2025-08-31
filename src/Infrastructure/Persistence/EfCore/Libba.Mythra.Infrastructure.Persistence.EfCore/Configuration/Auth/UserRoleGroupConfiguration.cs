using Libba.Mythra.Core.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libba.Mythra.Infrastructure.Persistence.EfCore.Configuration.Auth;

public class UserRoleGroupConfiguration : BaseConfiguration<UserRoleGroupEntity>
{
    public override void Configure(EntityTypeBuilder<UserRoleGroupEntity> builder)
    {
        base.Configure(builder);

        builder.ToTable("AUTH_USER_ROLE_GROUP");

        builder.Property(urg => urg.UserId).HasColumnName("AUTH_USER_ID");
        builder.Property(urg => urg.RoleGroupId).HasColumnName("AUTH_ROLE_GROUP_ID");

        builder.HasKey(urg => new { urg.UserId, urg.RoleGroupId });

        builder.HasOne(urg => urg.User).WithMany(u => u.UserRoleGroups).HasForeignKey(urg => urg.UserId);
        builder.HasOne(urg => urg.RoleGroup).WithMany(rg => rg.UserRoleGroups).HasForeignKey(urg => urg.RoleGroupId);
    }
}
