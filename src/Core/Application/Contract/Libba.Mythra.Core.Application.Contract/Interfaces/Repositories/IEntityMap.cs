namespace Libba.Mythra.Core.Application.Contract.Interfaces.Repositories;

public interface IEntityMap<TEntity>
    where TEntity : class
{
    void Configure();
}