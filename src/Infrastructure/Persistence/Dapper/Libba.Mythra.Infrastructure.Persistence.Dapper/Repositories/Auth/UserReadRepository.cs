using Dapper;
using Libba.Mythra.Core.Application.Contract.Interfaces;
using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories.Auth.User;
using Libba.Mythra.Core.Domain.Entities.Auth;

namespace Libba.Mythra.Infrastructure.Persistence.Dapper.Repositories.Auth;

public class UserReadRepository : ReadRepository<UserEntity>, IUserReadRepository
{
    public UserReadRepository(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
    {
    }

    public async Task<UserEntity?> GetByEmailAsync(string email)
    {
        using var connection = CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<UserEntity>(
            @"SELECT * FROM ""AUTH_USER"" WHERE ""EMAIL"" = @EMAIL", new { Email = email });
    }
}
