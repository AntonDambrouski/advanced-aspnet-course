using DaniilJobAggregator.Domain.Enum;

namespace DaniilJobAggregatorAPI.Domain.ViewModels
{
    public class VacancyViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public decimal? Salary { get; set; }
        public int? IdOrganisation { get; set; }
        public List<string> Requirements { get; set; }
        public List<string> Responsibilities { get; set; }
        public List<string> Conditions { get; set; }
        public ScheduleType ScheduleType { get; set; }
    }
}
