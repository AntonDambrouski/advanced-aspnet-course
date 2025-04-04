using NicksSchoolDiaryApi.Models;

namespace NicksSchoolDiaryApi.Services
{
    public class StudentService : IStudentService
    {
        private static readonly List<Student> _students = new List<Student>();
        
        static StudentService()
        {
            _students.Add(new Student() { Id = 1, Name = "John Smith", DateOfBirth = new DateOnly(2018, 5, 2), StudentClassId = 1});
            _students.Add(new Student() { Id = 2, Name = "Adam Wexler", DateOfBirth = new DateOnly(2019, 1, 20), StudentClassId = 1 });
            _students.Add(new Student() { Id = 3, Name = "Mark Daw", DateOfBirth = new DateOnly(2019, 3, 12), StudentClassId = 2 });
            _students.Add(new Student() { Id = 4, Name = "Selena Williams", DateOfBirth = new DateOnly(2017, 11, 21), StudentClassId = 4 });
        }

        public void AddStudent(Student student)
        {
            _students.Add(student);
        }

        public void DeleteStudent(int studentId)
        {
            var student = GetStudentById(studentId);
            if (student != null) 
            {
                _students.Remove(student);
            }
        }

        public List<Student> GetAllStudents()
        {
            return _students;
        }

        public Student? GetStudentById(int studentId)
        {
            return _students.FirstOrDefault(x => x.Id == studentId);
        }

        public List<Student> GetStudentsByClassId(int studentClassId)
        {
            return _students.Where(x => x.StudentClassId.Equals(studentClassId)).ToList();
        }

        public void UpdateStudent(Student student)
        {
            _students.Where(x => x.Id.Equals(student.Id)).ToList().ForEach(i => { 
                i.StudentClassId = student.StudentClassId;
                i.DateOfBirth = student.DateOfBirth;
                i.Name = student.Name;  
            }); 
        }
    }
}
