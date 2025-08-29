using Libba.Mythra.Core.Application.Contract.Interfaces;
using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories;
using Libba.Mythra.Core.Domain.Entities;
using Libba.Mythra.Infrastructure.Persistence.EfCore.Context;
using System.Collections;

namespace Libba.Mythra.Infrastructure.Persistence.EfCore;

public class UnitOfWork : IUnitOfWork
{
    private readonly MythraDbContext _dbContext;
    private readonly Hashtable _repositories;

    public UnitOfWork(MythraDbContext dbContext)
    {
        _dbContext = dbContext;
        _repositories = new Hashtable();
    }

    public Task<int> SaveChangesAsync() => _dbContext.SaveChangesAsync();

    public async ValueTask DisposeAsync() => await _dbContext.DisposeAsync();

    public IWriteRepository<T> GetWriteRepository<T>() where T : BaseEntity
    {
        var typeName = typeof(T).Name;
        if (!_repositories.ContainsKey(typeName))
        {
            var repository = new WriteRepository<T>(_dbContext);
            _repositories.Add(typeName, repository);
        }
        return (IWriteRepository<T>)_repositories[typeName];
    }
}