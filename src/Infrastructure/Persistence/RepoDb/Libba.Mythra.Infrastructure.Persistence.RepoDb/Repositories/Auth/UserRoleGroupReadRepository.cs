using Libba.Mythra.Core.Application.Contract.Interfaces;
using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories.Auth.UserRoleGroup;
using Libba.Mythra.Core.Domain.Entities.Auth;

namespace Libba.Mythra.Infrastructure.Persistence.RepoDb.Repositories.Auth;

public class UserRoleGroupReadRepository : ReadRepository<UserRoleGroupEntity>, IUserRoleGroupReadRepository
{
    public UserRoleGroupReadRepository(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
    {
    }
}
