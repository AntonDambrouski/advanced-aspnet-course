using NicksSchoolDiary.Validation;
using System.ComponentModel.DataAnnotations;

namespace NicksSchoolDiary.ViewModels
{
    public class StudentViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(45, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [DateOfBirth]
        public DateOnly DateOfBirth { get; set; }
        [Required]
        public int StudentClassId { get; set; }
        public string StudentClassName { get; set; } = string.Empty;    
    }
}
