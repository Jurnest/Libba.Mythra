using Libba.Mythra.Core.Domain.Entities.Auth;
using RepoDb;

namespace Libba.Mythra.Infrastructure.Persistence.RepoDb.Mapping.Auth;

public class RoleRoleGroupMap : BaseEntityMap<RoleRoleGroupEntity>
{
    protected override string GetTableName() => "AUTH_ROLE_ROLE_GROUP";

    public override void Configure()
    {
        base.Configure();

        EntityMapFluentDefinition<RoleRoleGroupEntity> mapper = FluentMapper.Entity<RoleRoleGroupEntity>();

        mapper.Column(e => e.RoleId, "AUTH_ROLE_ID");
        mapper.Column(e => e.RoleGroupId, "AUTH_ROLE_GROUP_ID");
    }
}