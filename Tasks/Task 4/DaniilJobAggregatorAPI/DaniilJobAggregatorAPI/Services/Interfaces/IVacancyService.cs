using DaniilJobAggregator.Domain.Entity;

namespace DaniilJobAggregator.Services.Interfaces
{
    public interface IvacancyService
    {
        public Vacancy? GetVacancyById(int idVacancy);
        public List<Vacancy> GetAllVacancies();
        public Vacancy? CreateVacancy(Vacancy vacancy);
        public Vacancy? EditVacancy(Vacancy vacancy);
        public bool DeleteVacancy(int idVacancy);
        public List<Vacancy> GetVacanciesByOrganisationId(int organisationId);
    }
}
