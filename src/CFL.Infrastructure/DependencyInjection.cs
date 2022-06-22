using CFL.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CFL.Infrastructure;

/// <summary>
/// Provides setup tools for DI
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
    
        var connectionString = "";
        
        services.AddDbContext<CFLDbContext>(options =>
            options.UseSqlServer(connectionString,
                b =>
                {
                    b.MigrationsAssembly(typeof(CFLDbContext).Assembly.FullName);
                }));

        services.AddScoped<IApplicationDbContext>(provider => provider.GetService<CFLDbContext>()!);

        return services;
    }
}
