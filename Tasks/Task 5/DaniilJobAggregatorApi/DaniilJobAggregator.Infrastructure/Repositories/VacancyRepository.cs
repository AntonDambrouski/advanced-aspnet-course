using DaniilJobAggregator.Core.Entities;
using DaniilJobAggregator.Core.Interfaces.Repositories;
using DaniilJobAggregator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace DaniilJobAggregator.Infrastructure.Repositories
{
    public class VacancyRepository(AppDbContext appDbContext)
        : BaseRepository<Vacancy>(appDbContext), IVacancyRepository
    {
        public async Task<List<Vacancy>> GetVacanciesByOrganisationIdAsync(int organisationId)
        {

            return await appDbContext.Vacancies
                                        .Where(x => x.IdOrganisation == organisationId)
                                        .ToListAsync();
        }
    }
}
