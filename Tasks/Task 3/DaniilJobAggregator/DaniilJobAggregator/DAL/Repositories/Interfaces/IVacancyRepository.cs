using DaniilJobAggregator.Domain.Entity;

namespace DaniilJobAggregator.DAL.Repositories.Interfaces
{
    public interface IVacancyRepository
    {
        List<Vacancy> GetAllVacancies();
        Vacancy GetVacancyById(int id);
        bool DeleteVacancy(int id);
        bool CreateVacancy(Vacancy vacancy);
        bool EditVacancy(Vacancy vacancy);
    }
}
