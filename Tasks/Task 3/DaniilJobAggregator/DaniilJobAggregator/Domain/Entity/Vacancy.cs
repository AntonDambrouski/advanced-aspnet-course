using DaniilJobAggregator.Domain.Enum;
using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DaniilJobAggregator.Domain.Entity
{
    public class Vacancy
    {
        public Vacancy() { }
        public Vacancy(int vacancyId, string name,
                        string description, string location,
                        decimal? salary, int? idOrganisation,
                        List<string> requirements,
                        List<string> responsibilities,
                        List<string> conditions,
                        ScheduleType scheduleType)
        {
            VacancyId = vacancyId;
            Name = name;
            Description = description;
            Location = location;
            Salary = salary;
            IdOrganisation = idOrganisation;
            Requirements = requirements;
            Responsibilities = responsibilities;
            Conditions = conditions;
            ScheduleType = scheduleType;
        }

        [Display(Name = "Id вакансии")]
        public int VacancyId { get; set; }
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
