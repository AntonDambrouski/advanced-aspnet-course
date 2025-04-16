using Microsoft.EntityFrameworkCore;
using MovieManager.Core.Entities;
using MovieManager.Core.Interfaces.Repositories;
using MovieManager.Infrustructure.Data;

namespace MovieManager.Infrustructure.Repositories;
internal class MoviesRepository(MovieContext context) : RepositoryBase<Movie>(context), IMoviesRepository
{
}
