using DaniilJobAggregator.DAL.Repositories.Interfaces;
using DaniilJobAggregator.Domain.Entity;
using DaniilJobAggregator.Services.Interfaces;

namespace DaniilJobAggregator.Services.Implementations
{
    public class VacancyService : IvacancyService
    {
        private readonly IVacancyRepository _vacancyRepository;

        public VacancyService(IVacancyRepository vacancyRepository)
        {
            _vacancyRepository = vacancyRepository;
        }
        public Vacancy? CreateVacancy(Vacancy vacancy)
        {
            return _vacancyRepository.CreateVacancy(vacancy);
        }

        public bool DeleteVacancy(int idVacancy)
        {
            return _vacancyRepository.DeleteVacancy(idVacancy);
        }

        public List<Vacancy> GetAllVacancies()
        {
            return _vacancyRepository.GetAllVacancies();
        }

        public Vacancy? GetVacancyById(int idVacancy)
        {
            return _vacancyRepository.GetVacancyById(idVacancy);
        }

        public Vacancy? EditVacancy(Vacancy vacancy)
        {
            return _vacancyRepository.EditVacancy(vacancy);
        }
        public List<Vacancy> GetVacanciesByOrganisationId(int organisationId)
        {
            List<Vacancy> list = _vacancyRepository.GetAllVacancies().Where(x => x.IdOrganisation == organisationId).ToList();
            return list;
        }
    }
}
