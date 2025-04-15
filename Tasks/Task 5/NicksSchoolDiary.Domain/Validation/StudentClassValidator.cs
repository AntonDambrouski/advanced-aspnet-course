using FluentValidation;
using NicksSchoolDiary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicksSchoolDiary.Domain.Validation
{
    public class StudentClassValidator: AbstractValidator<StudentClass>
    {
        public StudentClassValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Class name is required.")
                .Length(1, 25)
                .WithMessage("Class name must be between 1 and 25 characters.");
            
        }
    }
}
