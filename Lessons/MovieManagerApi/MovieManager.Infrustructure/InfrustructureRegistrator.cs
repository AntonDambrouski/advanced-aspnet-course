using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieManager.Core.Interfaces.Repositories;
using MovieManager.Infrustructure.Data;
using MovieManager.Infrustructure.Repositories;

namespace MovieManager.Infrustructure;
public static class InfrustructureRegistrator
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration, bool isDevelopment)
    {
        if (isDevelopment)
        {
            services.AddDbContext<MovieContext>(options =>
                 options.UseSqlServer(configuration.GetConnectionString("SqlServer")));
        }
        else
        {
           
        }

        services.AddScoped<IMoviesRepository, MoviesRepository>();
        services.AddScoped<IReviewsRepository, ReviewsRepository>();
    }
}
