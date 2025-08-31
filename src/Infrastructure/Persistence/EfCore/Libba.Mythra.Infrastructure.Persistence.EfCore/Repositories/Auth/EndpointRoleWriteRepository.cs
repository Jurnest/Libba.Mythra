using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories.Auth.EndpointRole;
using Libba.Mythra.Core.Domain.Entities.Auth;
using Libba.Mythra.Infrastructure.Persistence.EfCore.Context;

namespace Libba.Mythra.Infrastructure.Persistence.EfCore.Repositories.Auth;

public class EndpointRoleWriteRepository : WriteRepository<EndpointRoleEntity>, IEndpointRoleWriteRepository
{
    public EndpointRoleWriteRepository(MythraDbContext context) : base(context)
    {
    }
}
