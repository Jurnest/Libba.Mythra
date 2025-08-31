using Libba.Mythra.Core.Application.Contract.Interfaces;
using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories.Auth.EndpointRole;
using Libba.Mythra.Core.Domain.Entities.Auth;

namespace Libba.Mythra.Infrastructure.Persistence.RepoDb.Repositories.Auth;

public class EndpointRoleReadRepository : ReadRepository<EndpointRoleEntity>, IEndpointRoleReadRepository
{
    public EndpointRoleReadRepository(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
    {
    }
}