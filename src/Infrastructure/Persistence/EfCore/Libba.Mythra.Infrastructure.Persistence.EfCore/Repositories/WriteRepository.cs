using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories;
using Libba.Mythra.Core.Domain.Entities;
using Libba.Mythra.Infrastructure.Persistence.EfCore.Context;
using Microsoft.EntityFrameworkCore;

namespace Libba.Mythra.Infrastructure.Persistence.EfCore.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
{
    #region Dependencies
    private readonly MythraDbContext _context;

    public WriteRepository(MythraDbContext context)
    {
        _context = context;
    }

    private DbSet<T> Table => _context.Set<T>();
    #endregion

    public async Task AddAsync(T entity)
    {
        await Table.AddAsync(entity);
    }

    public async Task AddRangeAsync(IList<T> entities)
    {
        await Table.AddRangeAsync(entities);
    }

    public void Update(T entity)
    {
        Table.Update(entity);
    }

    public void Delete(T entity)
    {
        Table.Remove(entity);
    }
}
