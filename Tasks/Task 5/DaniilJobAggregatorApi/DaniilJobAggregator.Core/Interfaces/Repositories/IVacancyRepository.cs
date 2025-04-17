using DaniilJobAggregator.Core.Entities;


namespace DaniilJobAggregator.Core.Interfaces.Repositories
{
    public interface IVacancyRepository : IBaseRepository<Vacancy>
    {
       Task<List<Vacancy>> GetVacanciesByOrganisationIdAsync(int organisationId);
    }
}
