using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories;
using RepoDb;
using System.Reflection;

namespace Libba.Mythra.Infrastructure.Persistence.RepoDb.Mapping;

public static class RepoDbInitializer
{
    public static void Initialize(Assembly mappingAssembly)
    {
        PostgreSqlBootstrap.Initialize();

        var entityMapTypes = mappingAssembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract &&
                        t.GetInterfaces().Any(i => i.IsGenericType &&
                                                   i.GetGenericTypeDefinition() == typeof(IEntityMap<>)));

        foreach (var mapType in entityMapTypes)
        {
            var mapInstance = Activator.CreateInstance(mapType);
            var method = mapType.GetMethod("Configure");
            method?.Invoke(mapInstance, null);
        }
    }
}
