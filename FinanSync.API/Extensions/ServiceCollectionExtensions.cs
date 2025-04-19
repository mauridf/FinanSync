using FinanSync.API.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FinanSync.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTransactionalBehavior(this IServiceCollection services)
    {
        services.AddScoped<TransactionFilter>();
        services.AddMvc(options =>
        {
            options.Filters.AddService<TransactionFilter>();
            options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()); // Proteção CSRF
        });
        return services;
    }
}