using Libba.Mythra.Core.Domain.Entities;
using System.Linq.Expressions;

namespace Libba.Mythra.Core.Application.Contract.Interfaces.Repositories;

public interface IReadRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();

    Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate);

    Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
}