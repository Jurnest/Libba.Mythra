using Dapper;
using Libba.Mythra.Core.Application.Contract.Interfaces;
using Libba.Mythra.Core.Domain.Entities;
using Libba.Mythra.Infrastructure.Persistence.Dapper.Connection;
using Libba.Mythra.Infrastructure.Persistence.Dapper.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace Libba.Mythra.Infrastructure.Persistence.Dapper.Extensions;

public static class Registration
{
    public static IServiceCollection AddDapperRegistration(this IServiceCollection services)
    {
        RegisterDapperTypeMappings();

        services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();

        services.Scan(scan => scan
            .FromCallingAssembly()
            .AddClasses(classes => classes
                .Where(type => type.Name.EndsWith("Repository")))
            .AsMatchingInterface()
            .WithTransientLifetime());

        return services;
    }

    private static void RegisterDapperTypeMappings()
    {
        var domainAssembly = typeof(BaseEntity).Assembly;

        var entityTypes = domainAssembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(BaseEntity)));

        foreach (var entityType in entityTypes)
        {
            var setTypeMapMethods = typeof(SqlMapper).GetMethods()
                .Where(m => m.Name == nameof(SqlMapper.SetTypeMap) && m.IsGenericMethodDefinition);

            var setTypeMapMethod = setTypeMapMethods.FirstOrDefault(m => m.GetGenericArguments().Length == 1);

            if (setTypeMapMethod == null) continue;

            var genericSetTypeMapMethod = setTypeMapMethod.MakeGenericMethod(entityType);

            var mapperType = typeof(ColumnAttributeTypeMapper<>).MakeGenericType(entityType);
            var mapperInstance = Activator.CreateInstance(mapperType);

            genericSetTypeMapMethod.Invoke(null, new object[] { mapperInstance });

        }
    }
}