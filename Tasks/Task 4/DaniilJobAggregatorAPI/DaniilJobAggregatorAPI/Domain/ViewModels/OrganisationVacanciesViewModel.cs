using DaniilJobAggregator.Domain.Entity;

namespace DaniilJobAggregator.Domain.ViewModels
{
    public class OrganisationVacanciesViewModel
    {
        public Organisation Organisation { get; set; }
        public List<Vacancy> Vacancies { get; set; }

        public OrganisationVacanciesViewModel() { }

        public OrganisationVacanciesViewModel(Organisation organisation, List<Vacancy> vacancies)
        {
            Organisation = organisation;
            Vacancies = vacancies;
        }
    }
}
