using Libba.Mythra.Core.Application.Contract.Interfaces;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace Libba.Mythra.Infrastructure.Persistence.RepoDb.Connection;

public class DbConnectionFactory : IDbConnectionFactory
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public DbConnectionFactory(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("PostgreSqlConnection")
                            ?? throw new ArgumentNullException("PostgreSqlConnection connection string not found.");
    }

    public IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}
