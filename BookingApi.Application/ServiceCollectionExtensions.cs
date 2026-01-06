using Microsoft.Extensions.DependencyInjection;

namespace BookingApi.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Пока пусто — можно добавить сервисы позже
        return services;
    }
}
