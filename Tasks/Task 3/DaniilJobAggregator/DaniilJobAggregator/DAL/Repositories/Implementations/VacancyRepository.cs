using DaniilJobAggregator.DAL.Repositories.Interfaces;
using DaniilJobAggregator.Domain.Entity;
using DaniilJobAggregator.Domain.Enum;

namespace DaniilJobAggregator.DAL.Repositories.Implementations
{
    public class VacancyRepository : IVacancyRepository
    {
        private static readonly List<Vacancy> _vacancies = [];
        static VacancyRepository()
        {
            Vacancy vac = new Vacancy(3,
                ".Net Developer",
                "Описание вакансии",
                "Минск",
                3000,
                1,
                new List<string>(),
                new List<string>(),
                new List<string>(),
                ScheduleType.FULL);
            _vacancies.Add(vac);
            _vacancies.Add(new Vacancy
            (
                2,
                "Водитель",
                "Описание вакансии",
                "Брест",
                null,
                2,
                new List<string>(),
                new List<string>(),
                new List<string>(),
                ScheduleType.FULL
            ));
            _vacancies.Add(new Vacancy
            (
                1,
                "Инженер",
                "Описание вакансии",
                "Минск",
                2500,
                1,
                new List<string>(),
                new List<string>(),
                new List<string>(),
                ScheduleType.FULL
            ));
        }

        public bool CreateVacancy(Vacancy vacancy)
        {
            try
            {
                _vacancies.Add(vacancy);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteVacancy(int id)
        {
            try
            {
                _vacancies.Remove(GetVacancyById(id));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditVacancy(Vacancy vacancy)
        {
            try
            {
                Vacancy oldVacancy = GetVacancyById(vacancy.VacancyId);
                _vacancies.Remove(oldVacancy);
                _vacancies.Add(vacancy);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Vacancy> GetAllVacancies()
        {
            return _vacancies;
        }

        public Vacancy GetVacancyById(int id)
        {
            return _vacancies.FirstOrDefault(x => x.VacancyId == id);
        }
    }
}
