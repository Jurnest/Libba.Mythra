using Libba.Mythra.Core.Domain.Common;
using Libba.Mythra.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Libba.Mythra.Infrastructure.Persistence.EfCore.Context;

public class MythraDbContext : DbContext
{
    public MythraDbContext(DbContextOptions<MythraDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var entityTypes = typeof(BaseEntity).Assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && typeof(BaseEntity).IsAssignableFrom(t));

        foreach (var entityType in entityTypes)
        {
            // Her bir bulunan entity tipini EF Core modeline dahil et
            modelBuilder.Entity(entityType);
        }

        // Daha önce yazdığımız akıllı konfigürasyon kodu burada kalmaya devam ediyor.
        // Bu kod, artık modele dahil edilmiş olan entity'ler üzerinde çalışacak.
        var modelEntityTypes = modelBuilder.Model.GetEntityTypes()
            .Where(e => typeof(BaseEntity).IsAssignableFrom(e.ClrType));

        foreach (var modelEntityType in modelEntityTypes)
        {
            var clrType = modelEntityType.ClrType;
            var tableNameAttribute = clrType.GetCustomAttribute<TableNameAttribute>();
            if (tableNameAttribute != null)
            {
                modelBuilder.Entity(clrType).ToTable(tableNameAttribute.Name);
            }

            foreach (var property in modelEntityType.GetProperties())
            {
                var memberInfo = property.PropertyInfo;
                if (memberInfo == null) continue;

                var columnNameAttribute = memberInfo.GetCustomAttribute<ColumnNameAttribute>();
                if (columnNameAttribute != null)
                {
                    property.SetColumnName(columnNameAttribute.Name);
                }
            }
        }

    }
}
