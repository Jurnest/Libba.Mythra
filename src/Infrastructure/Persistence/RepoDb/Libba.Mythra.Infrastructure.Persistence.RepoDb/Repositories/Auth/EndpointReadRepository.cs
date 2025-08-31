using Libba.Mythra.Core.Application.Contract.Interfaces;
using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories.Auth.Endpoint;
using Libba.Mythra.Core.Domain.Entities.Auth;

namespace Libba.Mythra.Infrastructure.Persistence.RepoDb.Repositories.Auth;

public class EndpointReadRepository : ReadRepository<EndpointEntity>, IEndpointReadRepository
{
    public EndpointReadRepository(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
    {
    }
}
