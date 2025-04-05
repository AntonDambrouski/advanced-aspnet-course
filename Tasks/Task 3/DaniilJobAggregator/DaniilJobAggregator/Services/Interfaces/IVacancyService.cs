using DaniilJobAggregator.Domain.Entity;

namespace DaniilJobAggregator.Services.Interfaces
{
    public interface IvacancyService
    {
        public Vacancy GetVacancyById(int idVacancy);
        public List<Vacancy> GetAllVacancies();
        public bool CreateVacancy(Vacancy vacancy);
        public bool EditVacancy(Vacancy vacancy);
        public bool DeleteVacancy(int idVacancy);
        public List<Vacancy> GetVacanciesByOrganisationId(int organisationId);
    }
}
