using Microsoft.EntityFrameworkCore;
using redsea_api.Services.Banking.Commands;
using redsea_api.Services.Commands;
using redsea_api.Services.JWT;
using redsea_api.Services.Mail;
using redsea_database;
using redsea_database.DTOs.Banking;

namespace redsea_api.Services;

public static class ServicesExtensionBanking
{
    public static void AddBankingServices(this IServiceCollection services)
    {
        services.AddScoped<IMail, Mail.Mail>();
        services.AddSingleton<IJWT, JWT.JWT>();
    }
    
    public static async void AddDatabaseServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<DataContext>(options => options.UseSqlite(config["Database:ConnectionString"]));
        services.AddSingleton<ReadOnlyDataContext>();
    }
    
    public static void AddCommandServices(this IServiceCollection services)
    {
        services.AddSingleton<ICommandDispatcher, CommandDispatcher>();
        services.AddSingleton<ICommandHandler<GetClientInfoGetCommand, ClientInfo>, GetClientInfoCommandHandler>();
    }
    
    public static async void InitializeDatabase(this IServiceCollection services)
    {
        try {
            var dataContext = services.BuildServiceProvider().CreateScope().ServiceProvider.GetRequiredService<DataContext>();

            await dataContext.Database.MigrateAsync();
        }
        catch (Exception e)
        {
            throw new InvalidOperationException($"Error: ${e}");
        }
    }
}