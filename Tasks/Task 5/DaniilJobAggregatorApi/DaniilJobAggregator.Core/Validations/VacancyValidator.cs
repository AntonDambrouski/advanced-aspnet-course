using DaniilJobAggregator.Core.Entities;
using FluentValidation;


namespace DaniilJobAggregator.Core.Validations
{
    public class VacancyValidator : AbstractValidator<Vacancy>
    {
        public VacancyValidator()
        {
            RuleFor(vacancy => vacancy.Name)
                .NotEmpty()
                .WithMessage("Name is required.")
                .Length(1, 50)
                .WithMessage("Name must be 1 - 50 characters.");
        }
    }
}
