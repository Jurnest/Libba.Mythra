using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories.Auth.UserRoleGroup;
using Libba.Mythra.Core.Domain.Entities.Auth;
using Libba.Mythra.Infrastructure.Persistence.EfCore.Context;

namespace Libba.Mythra.Infrastructure.Persistence.EfCore.Repositories.Auth;

public class UserRoleGroupWriteRepository : WriteRepository<UserRoleGroupEntity>, IUserRoleGroupWriteRepository
{
    public UserRoleGroupWriteRepository(MythraDbContext context) : base(context)
    {
    }
}
