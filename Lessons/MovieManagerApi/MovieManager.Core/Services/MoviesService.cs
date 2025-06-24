using System.Threading.Tasks;
using FluentValidation;
using Microsoft.Extensions.Options;
using MovieManager.Core.Configurations;
using MovieManager.Core.Entities;
using MovieManager.Core.Exceptions;
using MovieManager.Core.Interfaces;
using MovieManager.Core.Interfaces.Repositories;

namespace MovieManager.Core.Services;

public class MoviesService(IMoviesRepository moviesRepository,
    IReviewsRepository reviewsRepository,
    IValidator<Movie> validator,
    IOptions<MoviesServiceConfig> config) : IMoviesService
{
    public async Task<List<Movie>> GetAllAsync(string searchTerm)
    {
        return await moviesRepository.GetAllAsync(searchTerm);
    }

    public Task<Movie> CreateAsync(Movie movie)
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

    public async Task<bool> DeleteMovieAsync(int id)
    {
        var deleted = await moviesRepository.DeleteAsync(id);
        return deleted;
    }

    public async Task<Movie?> GetAsync(int id)
    {
        return await moviesRepository.GetAsync(id);
    }


    public async Task<List<Movie>> GetAllMoviesAsync()
    {
        return await moviesRepository.GetAllAsync();
    }

    public async Task<Movie> UpdateMovieAsync(int id, Movie movieModel)
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

    public Task<List<Review>> GetReviewsByMovieIdAsync(int movieId)
    {
        return reviewsRepository.GetAllByMovieIdAsync(movieId);
    }

    public Task<Review> AddReviewToMovieAsync(int movieId, Review review)
    {
        review.MovieId = movieId;
        return reviewsRepository.CreateAsync(review);
    }
}
