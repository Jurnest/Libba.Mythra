using Libba.Mythra.Core.Application.Contract.Interfaces;
using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories;
using Libba.Mythra.Infrastructure.Persistence.EfCore.Context;
using Libba.Mythra.Infrastructure.Persistence.EfCore.Repositories;
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
        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

        services.Scan(scan => scan
            .FromCallingAssembly()
            .AddClasses(classes => classes
                .Where(type => type.Name.EndsWith("Repository")))
            .AsMatchingInterface()
            .WithScopedLifetime());

        return services;
    }
}