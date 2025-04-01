using MovieManager.Models;

namespace MovieManager.Services;
public interface IMovieManagerService
{
    void AddMovie(Movie movie);
    void DeleteMovie(int id);
    Movie? GetMovieById(int id);
    List<Movie> GetMovies();
    void UpdateMovie(Movie movie);
}