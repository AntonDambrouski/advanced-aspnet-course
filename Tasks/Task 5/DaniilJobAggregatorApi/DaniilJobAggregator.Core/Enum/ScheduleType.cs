using System.ComponentModel.DataAnnotations;


namespace DaniilJobAggregator.Core.Enum
{
    public enum ScheduleType
    {
        [Display(Name = "Не указан")]
        NONE = 0,
        [Display(Name = "Полный")]
        FULL = 1,
        [Display(Name = "Частичный")]
        PARTIAL = 2
    }
}
