using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories;
using Libba.Mythra.Core.Domain.Entities;
using Libba.Mythra.Core.Domain.Entities.Auth;
using RepoDb;

namespace Libba.Mythra.Infrastructure.Persistence.RepoDb.Mapping;

public abstract class BaseEntityMap<TEntity> : IEntityMap<TEntity> where TEntity : BaseEntity
{
    public virtual void Configure()
    {
        EntityMapFluentDefinition<TEntity> mapper = FluentMapper.Entity<TEntity>();

        mapper.Table(GetTableName());
        mapper.Column(e => e.Id, "ID");
        mapper.Column(e => e.CreatedBy, "CREATED_BY");
        mapper.Column(e => e.CreatedAt, "CREATED_AT");
        mapper.Column(e => e.UpdatedBy, "UPDATED_BY");
        mapper.Column(e => e.UpdatedAt, "UPDATED_AT");
    }

    protected abstract string GetTableName();
}
