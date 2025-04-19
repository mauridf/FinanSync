using FinanSync.Core.Interfaces.Services;
using FinanSync.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FinanSync.API.Extensions;

public static class AuthServiceCollectionExtensions
{
    public static IServiceCollection AddAuthServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        return services;
    }
}