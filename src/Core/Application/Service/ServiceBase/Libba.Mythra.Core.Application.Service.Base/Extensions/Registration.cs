using Libba.Mythra.Core.Application.Service.Base.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Libba.Mythra.Core.Application.Service.Base.Extensions;

public static class Registration
{
    public static IServiceCollection AddApplicationServiceBaseRegistration(this IServiceCollection services)
    {
        var assm = Assembly.GetExecutingAssembly();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assm));

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));

        return services;
    }
}