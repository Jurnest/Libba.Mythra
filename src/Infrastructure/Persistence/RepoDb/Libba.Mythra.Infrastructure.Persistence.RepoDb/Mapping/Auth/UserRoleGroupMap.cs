using Libba.Mythra.Core.Domain.Entities.Auth;
using RepoDb;

namespace Libba.Mythra.Infrastructure.Persistence.RepoDb.Mapping.Auth;

public class UserRoleGroupMap : BaseEntityMap<UserRoleGroupEntity>
{
    protected override string GetTableName() => "AUTH_USER_ROLE_GROUP";

    public override void Configure()
    {
        base.Configure();

        EntityMapFluentDefinition<UserRoleGroupEntity> mapper = FluentMapper.Entity<UserRoleGroupEntity>();

        mapper.Column(u => u.UserId, "AUTH_USER_ID");
        mapper.Column(u => u.RoleGroupId, "AUTH_ROLE_GROUP_ID");
    }
}