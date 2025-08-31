using Libba.Mythra.Core.Application.Contract.Interfaces;
using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories.Auth.Role;
using Libba.Mythra.Core.Domain.Entities.Auth;

namespace Libba.Mythra.Infrastructure.Persistence.RepoDb.Repositories.Auth;

public class RoleReadRepository : ReadRepository<RoleEntity>, IRoleReadRepository
{
    public RoleReadRepository(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
    {
    }
}
