using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories.Auth.RoleRoleGroup;
using Libba.Mythra.Core.Domain.Entities.Auth;
using Libba.Mythra.Infrastructure.Persistence.EfCore.Context;

namespace Libba.Mythra.Infrastructure.Persistence.EfCore.Repositories.Auth;

public class RoleRoleGroupWriteRepository : WriteRepository<RoleRoleGroupEntity>, IRoleRoleGroupWriteRepository
{
    public RoleRoleGroupWriteRepository(MythraDbContext context) : base(context)
    {
    }
}