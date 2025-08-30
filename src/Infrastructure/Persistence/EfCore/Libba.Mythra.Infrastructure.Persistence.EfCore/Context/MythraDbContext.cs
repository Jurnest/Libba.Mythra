using Libba.Mythra.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Libba.Mythra.Infrastructure.Persistence.EfCore.Context;

public class MythraDbContext : DbContext
{
    public MythraDbContext(DbContextOptions<MythraDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MythraDbContext).Assembly);

        var domainAssembly = typeof(BaseEntity).Assembly;

        var entityTypes = domainAssembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && typeof(BaseEntity).IsAssignableFrom(t));

        foreach (var entityType in entityTypes)
        {
            modelBuilder.Entity(entityType);
        }
    }
}
