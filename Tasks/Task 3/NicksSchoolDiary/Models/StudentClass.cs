using System.ComponentModel.DataAnnotations;

namespace NicksSchoolDiary.Models
{
    public class StudentClass
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = String.Empty;

       
    }
}
