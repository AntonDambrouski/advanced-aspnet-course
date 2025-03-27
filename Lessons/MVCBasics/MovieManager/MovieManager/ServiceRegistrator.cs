using MovieManager.Services;
using MovieManager.Storages;

namespace MovieManager;

public static class ServiceRegistrator
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddKeyedScoped<IMovieManagerService, MoviesManagerServiceMock>("mock");
        services.AddKeyedScoped<IMovieManagerService, MovieManagerService>("real");
        services.AddScoped<IReviewManagerService, ReviewManagerService>();
        services.AddScoped<IReviewsStorage, ReviewsStorage>();
    }

    public static IServiceCollection RegisterServices2(this IServiceCollection services)
    {
        services.AddScoped<IMovieManagerService, MoviesManagerServiceMock>();
        return services;
    }
}
