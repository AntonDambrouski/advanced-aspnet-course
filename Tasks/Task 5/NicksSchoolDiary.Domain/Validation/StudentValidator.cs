using FluentValidation;
using NicksSchoolDiary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicksSchoolDiary.Domain.Validation
{
    public class StudentValidator: AbstractValidator<Student>
    {
        public StudentValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name  for student is required.")
                .Length(5, 50)
                .WithMessage("Name must be between 5 and 50 characters.");

        }
    }
}
