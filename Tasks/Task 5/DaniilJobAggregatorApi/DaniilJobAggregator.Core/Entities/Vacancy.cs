using DaniilJobAggregator.Core.Enum;
using System.ComponentModel.DataAnnotations;


namespace DaniilJobAggregator.Core.Entities
{
    public class Vacancy : Entity
    {
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Расположение")]
        public string Location { get; set; }
        [Display(Name = "Зарплата")]
        public decimal? Salary { get; set; }
        [Display(Name = "Id организации")]
        public int? IdOrganisation { get; set; }
        [Display(Name = "Требования")]
        public List<string> Requirements { get; set; }
        [Display(Name = "Обязанности")]
        public List<string> Responsibilities { get; set; }
        [Display(Name = "Условия")]
        public List<string> Conditions { get; set; }
        [Display(Name = "График")]
        public ScheduleType ScheduleType { get; set; }
    }
}
