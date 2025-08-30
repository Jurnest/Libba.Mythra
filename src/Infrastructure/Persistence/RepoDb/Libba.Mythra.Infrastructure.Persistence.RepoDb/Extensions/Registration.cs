using Libba.Mythra.Core.Application.Contract.Interfaces;
using Libba.Mythra.Infrastructure.Persistence.RepoDb.Connection;
using Libba.Mythra.Infrastructure.Persistence.RepoDb.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace Libba.Mythra.Infrastructure.Persistence.RepoDb.Extensions;

public static class Registration
{
    public static IServiceCollection AddReadDataAccess(this IServiceCollection services, Action<RepoDbSettings>? configure = null)
    {
        RepoDbInitializer.Initialize(typeof(Registration).Assembly);

        services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();

        services.Scan(scan => scan
            .FromCallingAssembly()
            .AddClasses(classes => classes
                .Where(type => type.Name.EndsWith("Repository")))
            .AsMatchingInterface()
            .WithTransientLifetime());

        if (configure != null)
        {
            var settings = new RepoDbSettings();
            configure(settings);
        }

        return services;
    }

    public class RepoDbSettings
    {
    }
}
