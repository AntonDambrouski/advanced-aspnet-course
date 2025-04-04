using NicksSchoolDiary.Models;
namespace NicksSchoolDiary.ViewModels
{
    public class StudentClassWithStudents
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;               
        public List<Student> Students { get; set; } = new List<Student>();             
    }
}
