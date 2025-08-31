using Libba.Mythra.Core.Domain.Entities.Auth;
using RepoDb;

namespace Libba.Mythra.Infrastructure.Persistence.RepoDb.Mapping.Auth;

public class RoleGroupMap : BaseEntityMap<RoleGroupEntity>
{
    protected override string GetTableName() => "AUTH_ROLE_GROUP";

    public override void Configure()
    {
        base.Configure();

        EntityMapFluentDefinition<RoleGroupEntity> mapper = FluentMapper.Entity<RoleGroupEntity>();

        mapper.Column(e => e.Name, "NAME");
        mapper.Column(e => e.Description, "DESCRIPTION");
    }
}
