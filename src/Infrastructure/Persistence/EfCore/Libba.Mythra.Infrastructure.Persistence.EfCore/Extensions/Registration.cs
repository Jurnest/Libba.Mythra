using Libba.Mythra.Core.Application.Contract.Interfaces;
using Libba.Mythra.Infrastructure.Persistence.EfCore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Libba.Mythra.Infrastructure.Persistence.EfCore.Extensions;

public static class Registration
{
    public static IServiceCollection AddEfCoreRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MythraDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("PostgreSqlConnection")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.Scan(scan => scan
            .FromCallingAssembly()
            .AddClasses(classes => classes
                .Where(type => type.Name.EndsWith("Repository")))
            .AsMatchingInterface()
            .WithScopedLifetime());

        return services;
    }
}