using NicksSchoolDiary.Models;

namespace NicksSchoolDiary.Services
{
    public interface IStudentClassService
    {
        public void AddClass(StudentClass myClass);
        public void DeleteClass(int id);
        
        public void UpdateClass(StudentClass myClass);
        public StudentClass? GetClass(int id);
        
        public List<StudentClass> GetStudentClasses();  
    }
}
