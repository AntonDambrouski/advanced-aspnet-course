using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MovieManager.Core.Entities;

namespace MovieManager.Core.Validations;
public class MovieValidator : AbstractValidator<Movie>
{
    public MovieValidator()
    {
        RuleFor(movie => movie.Title)
            .NotEmpty()
            .WithMessage("Title is required.")
            .Length(1, 100)
            .WithMessage("Title must be between 1 and 100 characters.");

        RuleFor(movie => movie.Description)
            .NotEmpty()
            .WithMessage("Description is required.")
            .Length(1, 500)
            .WithMessage("Description must be between 1 and 500 characters.");

        RuleFor(movie => movie.Genre)
            .NotEmpty()
            .WithMessage("Genre is required.")
            .Length(1, 50)
            .WithMessage("Genre must be between 1 and 50 characters.");
    }
}
