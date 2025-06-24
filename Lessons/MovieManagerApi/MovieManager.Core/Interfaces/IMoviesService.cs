using MovieManager.Core.Entities;

namespace MovieManager.Core.Interfaces;
public interface IMoviesService
{
    Task<Review> AddReviewToMovieAsync(int movieId, Review review);
    Task<Movie> CreateAsync(Movie movie);
    Task<bool> DeleteMovieAsync(int id);
    Task<List<Movie>> GetAllAsync(string searchTerm);
    Task<List<Movie>> GetAllMoviesAsync();
    Task<Movie?> GetAsync(int id);
    Task<List<Review>> GetReviewsByMovieIdAsync(int movieId);
    Task<Movie> UpdateMovieAsync(int id, Movie movieModel);
}