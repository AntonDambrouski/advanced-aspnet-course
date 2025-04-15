using FluentValidation;
using NicksSchoolDiary.Domain.Exceptions;
using NicksSchoolDiary.Domain.Interfaces;
using NicksSchoolDiary.Domain.Interfaces.Repositories;
using NicksSchoolDiary.Domain.Models;
namespace NicksSchoolDiary.Domain.Services
{
    public class StudentClassService : IStudentClassService
    {
        private readonly IStudentClassRepository _studentClassRepository;
        private readonly IValidator<StudentClass> _studentClassValidator;
        public StudentClassService(IStudentClassRepository studentClassRepository, IValidator<StudentClass> studentClassValadator) 
        {
            _studentClassRepository = studentClassRepository;
            _studentClassValidator = studentClassValadator;
        }
        

        public async ValueTask<StudentClass> AddClassAsync(StudentClass myClass)
        {
            var result = _studentClassValidator.Validate(myClass);
            if (!result.IsValid)
            {
                throw new DomainException(result.Errors[0].ToString());
            }
            return await _studentClassRepository.AddAsync(myClass);
        }

        public async ValueTask<bool> DeleteClassAsync(int id)
        {
            StudentClass? studentClass = await GetClassAsync(id);
            if (studentClass != null)
            {
                return await _studentClassRepository.DeleteAsync(studentClass);
            }
            return false;
        }

        public async ValueTask<StudentClass> UpdateClassAsync(StudentClass myClass)
        {
            var result = _studentClassValidator.Validate(myClass);
            if (!result.IsValid) 
            {
                throw new DomainException(result.Errors[0].ToString());
            }
            var studentClass = await GetClassAsync(myClass.Id);
            if (studentClass == null)
            {
                throw new ArgumentNullException(nameof(studentClass), $"Student class id:{myClass.Id} not found");
            }
            return await _studentClassRepository.UpdateAsync(myClass);
        }

        public async ValueTask<StudentClass?> GetClassAsync(int id)
        {
            return await _studentClassRepository.GetStudentClassAsync(id);
        }

        public async ValueTask<List<StudentClass>> GetStudentClassesAsync()
        {
            return await _studentClassRepository.GetAllAsync();
        }
    }
}
