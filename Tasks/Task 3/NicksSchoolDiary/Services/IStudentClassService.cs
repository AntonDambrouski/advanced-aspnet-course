using NicksSchoolDiary.Models;

namespace NicksSchoolDiary.Services
{
    public interface IStudentClassService
    {
        void AddClass(StudentClass myClass);
        void DeleteClass(int id);        
        void UpdateClass(StudentClass myClass);
        StudentClass? GetClass(int id);        
        List<StudentClass> GetStudentClasses();  
    }
}
