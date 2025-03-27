using MovieManager.Models;

namespace MovieManager.Services;

public class MoviesManagerServiceMock : IMovieManagerService
{
    public void AddMovie(Movie movie)
    {
        throw new NotImplementedException();
    }

    public void DeleteMovie(int id)
    {
        throw new NotImplementedException();
    }

    public Movie? GetMovieById(int id)
    {
        throw new NotImplementedException();
    }

    public List<Movie> GetMovies()
    {
        throw new NotImplementedException();
    }

    public void UpdateMovie(Movie movie)
    {
        throw new NotImplementedException();
    }
}
