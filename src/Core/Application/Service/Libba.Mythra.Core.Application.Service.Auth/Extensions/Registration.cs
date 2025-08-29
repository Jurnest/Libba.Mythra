using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Libba.Mythra.Core.Application.Service.Auth.Extensions;

public static class Registration
{
    public static IServiceCollection AddAuthServiceRegistration(this IServiceCollection services)
    {
        var assm = Assembly.GetExecutingAssembly();

        services.AddValidatorsFromAssembly(assm);

        return services;
    }
}