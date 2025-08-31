using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories.Auth.RoleGroup;
using Libba.Mythra.Core.Domain.Entities.Auth;
using Libba.Mythra.Infrastructure.Persistence.EfCore.Context;

namespace Libba.Mythra.Infrastructure.Persistence.EfCore.Repositories.Auth;

public class RoleGroupWriteRepository : WriteRepository<RoleGroupEntity>, IRoleGroupWriteRepository
{
    public RoleGroupWriteRepository(MythraDbContext context) : base(context)
    {
    }
}
