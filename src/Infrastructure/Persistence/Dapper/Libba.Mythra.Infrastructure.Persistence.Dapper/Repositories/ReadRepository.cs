using Dapper;
using Libba.Mythra.Core.Application.Contract.Interfaces;
using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories;
using Libba.Mythra.Core.Domain.Common;
using Libba.Mythra.Core.Domain.Entities;
using System.Data;
using System.Reflection;

namespace Libba.Mythra.Infrastructure.Persistence.Dapper.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
{
    #region Dependencies
    private readonly IDbConnectionFactory _dbConnectionFactory;
    private readonly string _tableName;

    public ReadRepository(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
        _tableName = GetTableName();
    }

    private string GetTableName()
    {
        var type = typeof(T);
        var tableNameAttribute = type.GetCustomAttribute<TableNameAttribute>();
        if (tableNameAttribute != null)
        {
            return $"\"{tableNameAttribute.Name}\"";
        }
        return $"\"{type.Name}s\"";
    }


    protected IDbConnection CreateConnection() => _dbConnectionFactory.CreateConnection();
    #endregion

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<T>($"SELECT * FROM {_tableName}");

    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        using var connection = CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<T>(
            $"SELECT * FROM {_tableName} WHERE \"Id\" = @Id", new { Id = id });

    }
}
