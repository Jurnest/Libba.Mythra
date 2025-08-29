using Libba.Mythra.Core.Application.Contract.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Libba.Mythra.Core.Application.Mapper.Extensions;

public static class Registration
{
    public static IServiceCollection AddMythraMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<IMythraMapper, MythraMapper>();

        return services;
    }

}
