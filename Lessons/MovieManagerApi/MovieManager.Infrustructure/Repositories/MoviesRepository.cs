using Microsoft.EntityFrameworkCore;
using MovieManager.Core.Entities;
using MovieManager.Core.Interfaces.Repositories;
using MovieManager.Infrustructure.Data;

namespace MovieManager.Infrustructure.Repositories;
internal class MoviesRepository(MovieContext context) : RepositoryBase<Movie>(context), IMoviesRepository
{
    public async ValueTask<List<Movie>> GetAllAsync(string searchTerm)
    {

        var query = GetAllAsync(searchTerm, () => [nameof(Movie.Title), nameof(Movie.Description)]);
        return await query.ToListAsync();
    }
}
