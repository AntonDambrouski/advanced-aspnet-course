using NicksSchoolDiary.Models;

namespace NicksSchoolDiary.Services
{
    public interface IStudentService
    {
        void AddStudent(Student student);
        void DeleteStudent(int studentId);
        void UpdateStudent(Student student);
        Student? GetStudentById(int studentId);
        List<Student> GetAllStudents();
        List<Student> GetStudentsByClassId(int studentClassId);
    }
}
