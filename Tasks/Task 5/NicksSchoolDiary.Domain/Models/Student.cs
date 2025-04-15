using Microsoft.EntityFrameworkCore;
using NicksSchoolDiary.Api.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Xml.Linq;
namespace NicksSchoolDiary.Domain.Models
{

    [Index("Name", IsUnique = false, Name = "NameStudent")]
    public class Student
    {

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(45, MinimumLength = 3)]

        public string Name { get; set; } = string.Empty;

        [Required]
        [DateOfBirth]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        public int StudentClassId { get; set; }
        
        [ForeignKey("StudentClassId")]
        [JsonIgnore]
        public StudentClass StudentClass { get; set; } = new StudentClass();
    }
}
