using Microsoft.Extensions.DependencyInjection;

namespace CFL.Domain;

/// <summary>
/// Provides setup tools for DI
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        return services;
    }
}
