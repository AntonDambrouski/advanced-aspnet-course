using NicksSchoolDiary.Domain.Models;

namespace NicksSchoolDiary.Domain.Interfaces
{
    public interface IStudentService
    {
        ValueTask<Student> AddStudentAsync(Student student);
        ValueTask<bool> DeleteStudentAsync(int studentId);
        ValueTask<Student> UpdateStudentAsync(Student student);
        ValueTask<Student?> GetStudentByIdAsync(int studentId);
        ValueTask<List<Student>> GetAllStudentsAsync();
        ValueTask<List<Student>> GetStudentsByClassIdAsync(int studentClassId);
    }
}
