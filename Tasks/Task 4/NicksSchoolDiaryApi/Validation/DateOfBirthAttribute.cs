using System.ComponentModel.DataAnnotations;

namespace NicksSchoolDiaryApi.Validation
{
    public class DateOfBirthAttribute : ValidationAttribute
    {
        private readonly DateOnly _minDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-18));
        private readonly DateOnly _maxDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-6));


        public DateOfBirthAttribute()
        {
        }
        public DateOfBirthAttribute(string minDate, string maxDate)
        {
            _minDate = DateOnly.Parse(minDate);
            _maxDate = DateOnly.Parse(maxDate);
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateOnly date)
            {
                var result = date >= _minDate && date <= _maxDate;
                if (result == false)
                {
                    return new ValidationResult($"Date of Birth must be from {_minDate} to {_maxDate}");
                }
                return ValidationResult.Success;
            }

            return new ValidationResult("Incorrect date");
        }
    }
}
