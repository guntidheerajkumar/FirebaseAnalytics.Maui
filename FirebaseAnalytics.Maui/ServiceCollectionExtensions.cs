using Microsoft.Extensions.DependencyInjection;

namespace FirebaseAnalytics.Maui;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFirebaseAnalytics(this IServiceCollection services)
    {
        services.AddSingleton<IFirebaseAnalyticsService, FirebaseAnalyticsService>();
        return services;
    }
}