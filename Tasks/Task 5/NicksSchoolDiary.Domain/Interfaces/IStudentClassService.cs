using NicksSchoolDiary.Domain.Models;

namespace NicksSchoolDiary.Domain.Interfaces
{
    public interface IStudentClassService
    {
        ValueTask<StudentClass> AddClassAsync(StudentClass myClass);
        ValueTask<bool> DeleteClassAsync(int id);
        ValueTask<StudentClass> UpdateClassAsync(StudentClass myClass);
        ValueTask<StudentClass?> GetClassAsync(int id);
        ValueTask<List<StudentClass>> GetStudentClassesAsync();
    }
}
