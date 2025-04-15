using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace NicksSchoolDiary.Domain.Models
{
    [Index("Name", IsUnique = true, Name = "NameClass")]
    public class StudentClass
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int Id { get; set; }

        public string Name { get; set; } = String.Empty;
        [JsonIgnore]
        public List<Student>? Student { get; set; } = [];
    }
}
