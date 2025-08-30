using Libba.Mythra.Core.Application.Contract.Interfaces;
using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories;
using Libba.Mythra.Core.Domain.Entities;
using RepoDb;
using System.Data;
using System.Linq.Expressions;

namespace Libba.Mythra.Infrastructure.Persistence.RepoDb.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public ReadRepository(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    protected IDbConnection CreateConnection() => _dbConnectionFactory.CreateConnection();

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        using IDbConnection connection = CreateConnection();
        return await connection.QueryAllAsync<T>();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        using var connection = CreateConnection();
        return (await connection.QueryAsync<T>(e => e.Id == id))
               .FirstOrDefault();
    }

    public async Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate)
    {
        using IDbConnection connection = CreateConnection();
        return await connection.QueryAsync<T>(predicate);
    }

    public async Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
    {
        using var connection = CreateConnection();
        var result = await connection.QueryAsync<T>(predicate);
        return result.FirstOrDefault();
    }

}
