using DaniilJobAggregator.Core.Entities;


namespace DaniilJobAggregatorApi.ViewModels
{
    public class OrganisationViewModel
    {
        public string Name { get; set; }
        public List<Vacancy> Vacancies { get; set; }
    }
}
