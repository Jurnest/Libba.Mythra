using Libba.Mythra.Core.Application.Contract.Interfaces;
using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories.Auth.RoleRoleGroup;
using Libba.Mythra.Core.Domain.Entities.Auth;

namespace Libba.Mythra.Infrastructure.Persistence.RepoDb.Repositories.Auth;

public class RoleRoleGroupReadRepository : ReadRepository<RoleRoleGroupEntity>, IRoleRoleGroupReadRepository
{
    public RoleRoleGroupReadRepository(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
    {
    }
}
