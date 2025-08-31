using Libba.Mythra.Core.Domain.Entities.Auth;
using RepoDb;

namespace Libba.Mythra.Infrastructure.Persistence.RepoDb.Mapping.Auth;

public class RoleMap : BaseEntityMap<RoleEntity>
{
    protected override string GetTableName() => "AUTH_ROLE";

    public override void Configure()
    {
        base.Configure();

        EntityMapFluentDefinition<RoleEntity> mapper = FluentMapper.Entity<RoleEntity>();

        mapper.Column(e => e.Name, "NAME");
        mapper.Column(e => e.Description, "DESCRIPTION");
    }
}