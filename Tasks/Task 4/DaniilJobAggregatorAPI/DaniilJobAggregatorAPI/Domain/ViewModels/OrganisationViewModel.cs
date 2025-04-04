using DaniilJobAggregator.Domain.Entity;

namespace DaniilJobAggregatorAPI.Domain.ViewModels
{
    public class OrganisationViewModel
    {
        public string Name { get; set; }
        public List<Vacancy> Vacancies { get; set; }
    }
}
