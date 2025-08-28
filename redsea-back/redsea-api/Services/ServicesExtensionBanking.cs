using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using redsea_api.Services.Authentication.Commands;
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
        services.AddScoped<ICommandHandler<GetClientInfoCommand, ClientInfo>, GetClientInfoCommandHandler>();
        services.AddScoped<ICommandHandler<VerifyLoginCommand, bool>, VerifyLoginCommandHandler>();
        services.AddScoped<ICommandHandler<GenerateAuthTokenCommand, string>, GenerateAuthTokenCommandHandler>();
    }

    public static async void InitializeDatabase(this IServiceCollection services)
    {
        try
        {
            DataContext dataContext = services.BuildServiceProvider().CreateScope().ServiceProvider.GetRequiredService<DataContext>();

            await dataContext.Database.MigrateAsync();
        }
        catch (Exception e)
        {
            throw new InvalidOperationException($"Error: ${e}");
        }
    }

    public static void AddSecurityServices(this IServiceCollection services, IConfiguration config) => services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = config["JWT:Issuer"],
            ValidAudience = config["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:SigningKey"]))
        };
    });
}
