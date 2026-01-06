using Microsoft.Extensions.DependencyInjection;

namespace BookingApi.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Пока только DbContext уже добавлен
        return services;
    }
}