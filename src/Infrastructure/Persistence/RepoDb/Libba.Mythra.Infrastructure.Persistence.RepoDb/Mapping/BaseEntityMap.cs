using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories;
using Libba.Mythra.Core.Domain.Entities;
using RepoDb;

namespace Libba.Mythra.Infrastructure.Persistence.RepoDb.Mapping;

public abstract class BaseEntityMap<TEntity> : IEntityMap<TEntity>
    where TEntity : BaseEntity
{
    public virtual void Configure()
    {
        FluentMapper.Entity<TEntity>().Table(GetTableName())
                                      .Column(e => e.Id, "ID")
                                      .Column(e => e.CreatedBy, "CREATED_BY")
                                      .Column(e => e.CreatedAt, "CREATED_AT")
                                      .Column(e => e.UpdatedBy, "UPDATED_BY")
                                      .Column(e => e.UpdatedAt, "UPDATED_AT");
    }

    protected abstract string GetTableName();
}
