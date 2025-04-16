using System.Threading.Tasks;
using FluentValidation;
using Microsoft.Extensions.Options;
using MovieManager.Core.Configurations;
using MovieManager.Core.Entities;
using MovieManager.Core.Exceptions;
using MovieManager.Core.Interfaces;
using MovieManager.Core.Interfaces.Repositories;

namespace MovieManager.Core.Services;

public class MoviesService(IMoviesRepository moviesRepository, IValidator<Movie> validator, IOptions<MoviesServiceConfig> config) : IMoviesService
{
    public ValueTask<Movie> CreateAsync(Movie movie)
    {

        var validationResult = validator.Validate(movie);
        if (!validationResult.IsValid)
        {
            var message = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
            throw new DomainException(message);
        }

        var createdMovie = moviesRepository.CreateAsync(movie);
        return createdMovie;
    }

    public async ValueTask<bool> DeleteMovieAsync(int id)
    {
        var deleted = await moviesRepository.DeleteAsync(id);
        return deleted;
    }

    public async ValueTask<Movie?> GetAsync(int id)
    {
        return await moviesRepository.GetAsync(id);
    }


    public async ValueTask<List<Movie>> GetAllMoviesAsync()
    {
        return await moviesRepository.GetAllAsync();
    }

    public async ValueTask<Movie> UpdateMovieAsync(int id, Movie movieModel)
    {
        var savedMovie = await GetAsync(id);
        if (savedMovie == null)
        {
            throw new DomainException($"Movie with id {id} not found.");
        }

        savedMovie.Title = movieModel.Title;
        if (savedMovie.Description?.Length > config.Value.AllowedDescriptionLength)
        {
            throw new DomainException("");
        }

        savedMovie.Description = movieModel.Description;

        return await moviesRepository.UpdateAsync(savedMovie);
    }
}
