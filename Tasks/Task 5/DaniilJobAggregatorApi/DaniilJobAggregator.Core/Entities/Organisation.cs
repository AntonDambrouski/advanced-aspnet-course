using System.ComponentModel.DataAnnotations;


namespace DaniilJobAggregator.Core.Entities
{
    public class Organisation : Entity
    {
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        [Display(Name = "Список вакансий")]
        public List<Vacancy> Vacancies { get; set; }
    }
}
