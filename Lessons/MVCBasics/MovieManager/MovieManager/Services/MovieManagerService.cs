using MovieManager.Models;

namespace MovieManager.Services;

public class MovieManagerService : IMovieManagerService
{
    private static readonly List<Movie> _movies = [];

    static MovieManagerService()
    {
        _movies.Add(new Movie { Id = 1, Title = "The Shawshank Redemption", Genre = "Drama", Year = 1994 });
        _movies.Add(new Movie { Id = 2, Title = "The Godfather", Genre = "Crime", Year = 1972 });
        _movies.Add(new Movie { Id = 3, Title = "The Dark Knight", Genre = "Action", Year = 2008 });
    }

    public void AddMovie(Movie movie)
    {
        _movies.Add(movie);
    }

    public List<Movie> GetMovies()
    {
        return _movies;
    }

    public Movie? GetMovieById(int id)
    {
        return _movies.FirstOrDefault(m => m.Id == id);
    }

    public void UpdateMovie(Movie movie)
    {
        var existingMovie = _movies.FirstOrDefault(m => m.Id == movie.Id);
        if (existingMovie != null)
        {
            existingMovie.Title = movie.Title;
            existingMovie.Genre = movie.Genre;
            existingMovie.Year = movie.Year;
        }
    }

    public void DeleteMovie(int id)
    {
        var movie = _movies.FirstOrDefault(m => m.Id == id);
        if (movie != null)
        {
            _movies.Remove(movie);
        }
    }
}
