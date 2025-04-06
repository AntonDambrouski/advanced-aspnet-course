using NicksSchoolDiaryApi.Models;
namespace NicksSchoolDiaryApi.Services
{
    public class StudentClassService : IStudentClassService
    {
        private static readonly List<StudentClass> _studentClasses = new List<StudentClass>();
        static StudentClassService()
        {
            _studentClasses.Add(new StudentClass() { Id = 1, Name = "1A" });
            _studentClasses.Add(new StudentClass() { Id = 2, Name = "1B" });
            _studentClasses.Add(new StudentClass() { Id = 3, Name = "1C" });
            _studentClasses.Add(new StudentClass() { Id = 4, Name = "2A" });
        }

        public void AddClass(StudentClass myClass)
        {
            _studentClasses.Add(myClass);
        }

        public void DeleteClass(int id)
        {
            StudentClass? studentClass = GetClass(id);
            if (studentClass != null)
            {
                _studentClasses.Remove(studentClass);
            }
        }

        public void UpdateClass(StudentClass myClass)
        {
            _studentClasses.Where(x => x.Id.Equals(myClass.Id)).ToList().ForEach(i => i.Name = myClass.Name);
        }

        public StudentClass? GetClass(int id)
        {
            return _studentClasses.FirstOrDefault(x => x.Id == id);
        }

        public List<StudentClass> GetStudentClasses()
        {
            return _studentClasses;
        }
    }
}
