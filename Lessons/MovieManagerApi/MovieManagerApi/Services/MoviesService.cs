using MovieManagerApi.Entities;

namespace MovieManagerApi.Services;

public class MoviesService : IMoviesService
{
    private static readonly List<Movie> _movies = [];

    static MoviesService()
    {
        // Sample data
        _movies.Add(new Movie { Id = 1, Title = "Inception", Description = "A mind-bending thriller", Genre = "Sci-Fi" });
        _movies.Add(new Movie { Id = 2, Title = "The Godfather", Description = "A crime drama", Genre = "Crime" });
        _movies.Add(new Movie { Id = 3, Title = "The Dark Knight", Description = "A superhero film", Genre = "Action" });
    }

    public void AddMovie(Movie movie)
    {
        _movies.Add(movie);
    }

    public void DeleteMovie(int id)
    {
        var movie = _movies.FirstOrDefault(m => m.Id == id);
        if (movie != null)
        {
            _movies.Remove(movie);
        }
    }

    public Movie GetMovie(int id)
    {
        return _movies.FirstOrDefault(m => m.Id == id);
    }


    public List<Movie> GetAllMovies()
    {
        return _movies;
    }

    public void UpdateMovie(int id, Movie updatedMovie)
    {
        var movie = _movies.FirstOrDefault(m => m.Id == id);
        if (movie != null)
        {
            movie.Title = updatedMovie.Title;
            movie.Description = updatedMovie.Description;
            movie.Genre = updatedMovie.Genre;
        }
    }
}
