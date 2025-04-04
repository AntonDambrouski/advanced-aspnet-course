using NicksSchoolDiaryApi.Validation;
using System.ComponentModel.DataAnnotations;

namespace NicksSchoolDiaryApi.Models
{

    
    public class Student
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
    }
}
