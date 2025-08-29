using System.Data;

namespace Libba.Mythra.Core.Application.Contract.Interfaces;

/// <summary>
/// Defines a factory for creating database connections.
/// This abstracts the underlying database provider and connection string management.
/// </summary>
public interface IDbConnectionFactory
{
    /// <summary>
    /// Creates and returns a new open database connection.
    /// </summary>
    /// <returns>A new instance of IDbConnection.</returns>
    IDbConnection CreateConnection();
}
