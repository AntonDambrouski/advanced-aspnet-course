using NicksSchoolDiaryApi.Models;

namespace NicksSchoolDiaryApi.Services
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
