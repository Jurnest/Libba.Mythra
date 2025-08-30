using Libba.Mythra.Core.Application.Contract.Interfaces;
using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories.Auth.User;
using Libba.Mythra.Core.Domain.Entities.Auth;

namespace Libba.Mythra.Infrastructure.Persistence.RepoDb.Repositories.Auth;

public class UserReadRepository : ReadRepository<UserEntity>, IUserReadRepository
{
    public UserReadRepository(IDbConnectionFactory dbConnectionFactory)
        : base(dbConnectionFactory)
    {
    }

    public async Task<UserEntity?> GetByEmailAsync(string email)
    {
        return await GetFirstOrDefaultAsync(u => u.Email == email);
    }
}

