using CFL.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CFL.Infrastructure;

/// <summary>
/// Provides setup tools for DI
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var connectionString =
            new ConfigurationBuilder().AddJsonFile("appsettings.json").Build()
                .GetSection("ConnectionStrings")["CflDbConnection"];

        services.AddDbContext<CFLDbContext>(options =>
            options.UseSqlServer(connectionString,
                b =>
                {
                    b.MigrationsAssembly(typeof(CFLDbContext).Assembly.FullName);
                    b.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "System");
                }));

        services.AddScoped<IApplicationDbContext>(provider => provider.GetService<CFLDbContext>());

    
        return services;
    }
}
