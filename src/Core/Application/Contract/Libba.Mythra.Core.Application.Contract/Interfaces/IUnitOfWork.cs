using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories;
using Libba.Mythra.Core.Domain.Entities;

namespace Libba.Mythra.Core.Application.Contract.Interfaces;

public interface IUnitOfWork : IAsyncDisposable
{
    /// <summary>
    /// Gets a write repository for a specific entity type.
    /// </summary>
    /// <typeparam name="T">The type of the entity, which must be a BaseEntity.</typeparam>
    /// <returns>An instance of IWriteRepository for the specified entity type.</returns>
    IWriteRepository<T> GetWriteRepository<T>() where T : BaseEntity;

    /// <summary>
    /// Saves all changes made in this unit of work to the database.
    /// </summary>
    /// <returns>The number of state entries written to the database.</returns>
    Task<int> SaveChangesAsync();
}
