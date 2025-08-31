using Libba.Mythra.Core.Domain.Entities.Auth;
using RepoDb;

namespace Libba.Mythra.Infrastructure.Persistence.RepoDb.Mapping.Auth;

public class EndpointMap : BaseEntityMap<EndpointEntity>
{
    protected override string GetTableName() => "AUTH_ENDPOINT";

    public override void Configure()
    {
        base.Configure();

        EntityMapFluentDefinition<EndpointEntity> mapper = FluentMapper.Entity<EndpointEntity>();

        mapper.Column(e => e.ControllerName, "CONTROLLER_NAME");
        mapper.Column(e => e.ActionName, "ACTION_NAME");
        mapper.Column(e => e.HttpVerb, "HTTP_VERB");
        mapper.Column(e => e.Path, "PATH");
    }
}
