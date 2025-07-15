using MovieManager.Core.Entities;

namespace MovieManager.Core.Interfaces.Repositories;
public interface IMoviesRepository : IRepositoryBase<Movie>
{
    Task<List<Movie>> GetAllAsync(string searchTerm);
}
