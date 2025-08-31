using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories.Auth.Role;
using Libba.Mythra.Core.Domain.Entities.Auth;
using Libba.Mythra.Infrastructure.Persistence.EfCore.Context;

namespace Libba.Mythra.Infrastructure.Persistence.EfCore.Repositories.Auth;

public class RoleWriteRepository : WriteRepository<RoleEntity>, IRoleWriteRepository
{
    public RoleWriteRepository(MythraDbContext context) : base(context)
    {
    }
}
