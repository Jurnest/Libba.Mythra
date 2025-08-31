using Libba.Mythra.Core.Domain.Entities.Auth;
using RepoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libba.Mythra.Infrastructure.Persistence.RepoDb.Mapping.Auth;

public class EndpointRoleMap : BaseEntityMap<EndpointRoleEntity>
{
    protected override string GetTableName() => "AUTH_ENDPOINT_ROLE";

    public override void Configure()
    {
        base.Configure();

        EntityMapFluentDefinition<EndpointRoleEntity> mapper = FluentMapper.Entity<EndpointRoleEntity>();

        mapper.Column(e => e.Endpoint, "AUTH_ENDPOINT_ID");
        mapper.Column(e => e.RoleId, "AUTH_ROLE_ID");
    }
}
