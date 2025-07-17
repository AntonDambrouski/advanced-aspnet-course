using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MovieManager.Core.Configurations;
using MovieManager.Core.Contexts;
using MovieManager.Core.Entities;
using MovieManager.Core.Exceptions;
using MovieManager.Core.Interfaces;
using MovieManager.Core.Interfaces.Repositories;

namespace MovieManager.Core.Services;

public class MoviesService(IMoviesRepository moviesRepository,
    IReviewsRepository reviewsRepository,
    IValidator<Movie> validator,
    UserContext userContext,
    IOptions<MoviesServiceConfig> config,
    IFileUploadService fileUploadService) : IMoviesService
{
    private readonly string PostersFolderPath = "static/posters";
    private readonly HashSet<string> AllowedFileExtensions = new HashSet<string>
    {
        ".jpg", ".jpeg", ".png", ".gif"
    };

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
        Console.WriteLine($"User {userContext.UserId} requested movies...");

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

    public async Task<string> UploadPosterAsync(int movieId, IFormFile file)
    {
        var movie = await GetAsync(movieId);
        if (movie == null)
        {
            throw new DomainException($"Movie with id {movieId} not found.");
        }

        var fileName = file.FileName;
        var fileExtension = Path.GetExtension(fileName).ToLowerInvariant();
        if (!AllowedFileExtensions.Contains(fileExtension))
        {
            throw new DomainException($"File extension {fileExtension} is not allowed." +
                $" Allowed extensions are: {string.Join(", ", AllowedFileExtensions)}");
        }

        var uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";

        await fileUploadService.UploadFileAsync(PostersFolderPath, uniqueFileName, file);

        movie.PosterFileName = uniqueFileName;
        await moviesRepository.UpdateAsync(movie);

        return uniqueFileName;
    }
}
