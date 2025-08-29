using Libba.Mythra.Core.Domain.Entities;

namespace Libba.Mythra.Core.Application.Contract.Interfaces.Repositories;

/// <summary>
/// Defines the contract for a generic write repository for entities.
/// It provides methods for creating, updating, and deleting entities.
/// This follows the Command part of CQRS.
/// </summary>
/// <typeparam name="T">The type of the entity, which must be a class derived from BaseEntity.</typeparam>
public interface IWriteRepository<T> where T : BaseEntity
{
    /// <summary>
    /// Adds a new entity.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <returns>Task result.</returns>
    Task AddAsync(T entity);

    /// <summary>
    /// Adds a range of new entities.
    /// </summary>
    /// <param name="entities">The list of entities to add.</param>
    /// <returns>Task result.</returns>
    Task AddRangeAsync(IList<T> entities);

    /// <summary>
    /// Marks an existing entity as modified. The actual update happens on SaveChangesAsync.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    void Update(T entity);

    /// <summary>
    /// Marks an existing entity for deletion. The actual deletion happens on SaveChangesAsync.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    void Delete(T entity);
}