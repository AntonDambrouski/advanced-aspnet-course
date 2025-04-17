using DaniilJobAggregator.Core.Entities;


namespace DaniilJobAggregator.Core.Interfaces
{
    public interface IvacancyService
    {
        Task<Vacancy?> GetVacancyById(int idVacancy);
        Task<List<Vacancy>> GetAllVacancies();
        Task<Vacancy?> CreateVacancy(Vacancy vacancy);
        Task<Vacancy?> EditVacancy(Vacancy vacancy);
        Task<bool> DeleteVacancy(int idVacancy);
        Task<List<Vacancy>> GetVacanciesByOrganisationId(int organisationId);
    }
}
