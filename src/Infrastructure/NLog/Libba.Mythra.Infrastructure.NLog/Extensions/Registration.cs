using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace Libba.Mythra.Infrastructure.NLog.Extensions;

public static class Registration
{
    public static IServiceCollection AddNLogRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders(); // Varsayılan loglama sağlayıcılarını temizle
            loggingBuilder.SetMinimumLevel(LogLevel.Trace); // Tüm seviyelerdeki logları NLog'a ilet
        });

        services.AddNLogWeb();

        return services;
    }
}
