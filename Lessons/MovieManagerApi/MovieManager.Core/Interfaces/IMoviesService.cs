using MovieManager.Core.Entities;

namespace MovieManager.Core.Interfaces;
public interface IMoviesService
{
    ValueTask<Movie> CreateAsync(Movie movie);
    ValueTask<bool> DeleteMovieAsync(int id);
    ValueTask<List<Movie>> GetAllAsync(string searchTerm);
    ValueTask<List<Movie>> GetAllMoviesAsync();
    ValueTask<Movie?> GetAsync(int id);
    ValueTask<Movie> UpdateMovieAsync(int id, Movie movieModel);
}