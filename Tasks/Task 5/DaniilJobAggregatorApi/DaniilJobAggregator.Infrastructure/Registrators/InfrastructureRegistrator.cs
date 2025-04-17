using DaniilJobAggregator.Core.Interfaces.Repositories;
using DaniilJobAggregator.Infrastructure.Data;
using DaniilJobAggregator.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace DaniilJobAggregator.Infrastructure.Registrators
{
    public static class InfrastructureRegistrator
    {
        public static void RegisterServices(this IServiceCollection services,
                                            IConfiguration configuration,
                                            bool isDevelopment)
        {
            if (isDevelopment)
            {
                services.AddDbContext<AppDbContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            }

            services.AddScoped<IOrganisationRepository, OrganisationRepository>();
            services.AddScoped<IVacancyRepository, VacancyRepository>();
        }
    }
}
