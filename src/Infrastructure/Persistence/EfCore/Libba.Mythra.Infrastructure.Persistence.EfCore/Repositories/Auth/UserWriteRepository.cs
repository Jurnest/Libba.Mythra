using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories.Auth.User;
using Libba.Mythra.Core.Domain.Entities.Auth;
using Libba.Mythra.Infrastructure.Persistence.EfCore.Context;

namespace Libba.Mythra.Infrastructure.Persistence.EfCore.Repositories.Auth;

public class UserWriteRepository : WriteRepository<UserEntity>, IUserWriteRepository
{
    public UserWriteRepository(MythraDbContext context) : base(context)
    {
    }
}
