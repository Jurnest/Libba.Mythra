using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Libba.Mythra.Core.Application.Contract.Extensions;

public static class Registration
{
    public static IServiceCollection AddApplicationContractRegistration(this IServiceCollection services)
    {
        var assm = Assembly.GetExecutingAssembly();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assm));

        return services;
    }
}