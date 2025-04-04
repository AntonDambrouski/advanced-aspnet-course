﻿using System.ComponentModel.DataAnnotations;

namespace DaniilJobAggregator.Domain.Enum
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
