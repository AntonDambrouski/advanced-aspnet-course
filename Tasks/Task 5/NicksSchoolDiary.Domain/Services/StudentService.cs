using FluentValidation;
using NicksSchoolDiary.Domain.Exceptions;
using NicksSchoolDiary.Domain.Interfaces;
using NicksSchoolDiary.Domain.Interfaces.Repositories;
using NicksSchoolDiary.Domain.Models;

namespace NicksSchoolDiary.Domain.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentClassRepository _studentClassRepository;
        private readonly IValidator<Student> _studentValidator;
        public StudentService(IStudentRepository studentRepository, IStudentClassRepository studentClassRepository, IValidator<Student> studentValidator) 
        {
            _studentRepository = studentRepository;
            _studentClassRepository = studentClassRepository;
            _studentValidator = studentValidator;
        }
        
        public async Task<Student> AddStudentAsync(Student student)
        {
            
            var studentClass = await _studentClassRepository.GetStudentClassAsync(student.StudentClassId);
            if (studentClass is null)
            {
                studentClass = await _studentClassRepository.GetStudentClassAsync(1);
            }
            if (studentClass != null)
            {
                student.StudentClass = studentClass;
            }
            var result = _studentValidator.Validate(student);
            if (!result.IsValid)
            {
                throw new DomainException(result.Errors[0].ToString());
            }
      

            return await _studentRepository.AddAsync(student);

        }

        public async Task<bool> DeleteStudentAsync(int studentId)
        {
            var student = await _studentRepository.GetStudentByIdAsync(studentId);
            if (student == null)
            {
                return false;
            }
            return await  _studentRepository.DeleteAsync(student);
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<Student?> GetStudentByIdAsync(int studentId)
        {
            return await _studentRepository.GetStudentByIdAsync(studentId);
                
        }

        public async Task<List<Student>> GetStudentsByClassIdAsync(int studentClassId)
        {
            return await _studentRepository.GetStudentsByClassIdAsync(studentClassId);
        }

        public async Task<Student> UpdateStudentAsync(Student student)
        {
            var result = _studentValidator.Validate(student);
            if (!result.IsValid)
            {
                throw new DomainException(result.Errors[0].ToString());
            }
            var studentForUpdate = await _studentRepository.GetStudentByIdAsync(student.Id);
            if (studentForUpdate == null)
            {
                throw new ArgumentException(student.Id.ToString());
            }

            studentForUpdate.DateOfBirth = student.DateOfBirth;
            studentForUpdate.StudentClassId = student.StudentClassId;
            studentForUpdate.Name = student.Name;


            return await _studentRepository.UpdateAsync(studentForUpdate);
        }
    }
}
