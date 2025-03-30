using NicksSchoolDiary.Models;

namespace NicksSchoolDiary.Services
{
    public interface IStudentService
    {
        public void AddStudent(Student student);
        public void DeleteStudent(int studentId);

        public void UpdateStudent(Student student);
        public Student? GetStudentById(int studentId);
        public List<Student> GetAllStudents();

        public List<Student> GetStudentsByClassId(int studentClassId);
    }
}
