using MovieManagerApi.Entities;

namespace MovieManagerApi.Services;
public interface IMoviesService
{
    void AddMovie(Movie movie);
    void DeleteMovie(int id);
    List<Movie> GetAllMovies();
    Movie GetMovie(int id);
    void UpdateMovie(int id, Movie updatedMovie);
}