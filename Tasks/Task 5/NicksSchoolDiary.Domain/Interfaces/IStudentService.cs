using NicksSchoolDiary.Domain.Models;

namespace NicksSchoolDiary.Domain.Interfaces
{
    public interface IStudentService
    {
        Task<Student> AddStudentAsync(Student student);
        Task<bool> DeleteStudentAsync(int studentId);
        Task<Student> UpdateStudentAsync(Student student);
        Task<Student?> GetStudentByIdAsync(int studentId);
        Task<List<Student>> GetAllStudentsAsync();
        Task<List<Student>> GetStudentsByClassIdAsync(int studentClassId);
    }
}
