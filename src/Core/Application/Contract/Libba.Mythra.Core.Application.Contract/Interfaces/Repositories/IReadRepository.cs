using Libba.Mythra.Core.Domain.Entities;

namespace Libba.Mythra.Core.Application.Contract.Interfaces.Repositories;

public interface IReadRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
}