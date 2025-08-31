using Libba.Mythra.Infrastructure.Persistence.RepoDb.Extensions;
using Libba.Mythra.Core.Application.Contract.Extensions;
using Libba.Mythra.Core.Application.Service.Auth.Extensions;
using Libba.Mythra.Core.Application.Service.Base.Extensions;
using Libba.Mythra.Infrastructure.NLog.Extensions;
using NLog.Web;
using NLog;
using Libba.Mythra.Infrastructure.Persistence.EfCore.Extensions;
using Libba.Mythra.Core.Application.Mapper.Extensions;
using Libba.Mythra.Presentation.WebAPI.Middlewares;
using Libba.Mythra.Presentation.WebAPI.ActionFilters;


try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseNLog();

    var logger = LogManager.GetCurrentClassLogger();
    logger.Info("Mythra Is Starting...");


    // Add services to the container.
    builder.Services.AddEfCoreRegistration(builder.Configuration);
    builder.Services.AddNLogRegistration(builder.Configuration);
    builder.Services.AddApplicationContractRegistration();
    builder.Services.AddMythraMapper();
    builder.Services.AddReadDataAccess(settings =>
    {
    });
    builder.Services.AddApplicationServiceBaseRegistration();

    builder.Services.AddAuthServiceRegistration();

    builder.Services.AddControllers(options =>
    {
        options.Filters.Add<ValidateModelActionFilter>();
    });
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();


    #if DEBUG
        app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
    #endif


    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    LogManager.GetCurrentClassLogger().Error(ex, "Mythra Can't Be Started.");
    throw;
}
finally
{
    LogManager.Shutdown();
}