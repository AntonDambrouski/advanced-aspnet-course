using Microsoft.EntityFrameworkCore;
using MovieManager.Core.Entities;

namespace MovieManager.Infrustructure.Data;
public class MovieContext(DbContextOptions<MovieContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Review> Reviews { get; set; }
}
