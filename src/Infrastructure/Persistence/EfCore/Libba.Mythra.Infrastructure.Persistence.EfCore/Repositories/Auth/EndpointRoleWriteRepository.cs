using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories.Auth.Endpoint;
using Libba.Mythra.Core.Domain.Entities.Auth;
using Libba.Mythra.Infrastructure.Persistence.EfCore.Context;

namespace Libba.Mythra.Infrastructure.Persistence.EfCore.Repositories.Auth;

public class EndpointRoleWriteRepository : WriteRepository<EndpointRoleEntity>, IEndpointWriteRepository
{
    public EndpointRoleWriteRepository(MythraDbContext context) : base(context)
    {
    }
}
