using System.ComponentModel.DataAnnotations;

namespace DaniilJobAggregator.Domain.Entity
{
    public class Organisation
    {
        [Display(Name = "Id организации")]
        public int OrganisationId { get; set; }
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        [Display(Name = "Список вакансий")]
        public List<Vacancy> Vacancies { get; set; }
    }
}
