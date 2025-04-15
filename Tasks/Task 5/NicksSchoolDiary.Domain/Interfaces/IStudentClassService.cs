using NicksSchoolDiary.Domain.Models;

namespace NicksSchoolDiary.Domain.Interfaces
{
    public interface IStudentClassService
    {
        Task<StudentClass> AddClassAsync(StudentClass myClass);
        Task<bool> DeleteClassAsync(int id);
        Task<StudentClass> UpdateClassAsync(StudentClass myClass);
        Task<StudentClass?> GetClassAsync(int id);
        Task<List<StudentClass>> GetStudentClassesAsync();
    }
}
