using Microsoft.EntityFrameworkCore;
using MovieManager.Core.Entities;
using MovieManager.Core.Interfaces.Repositories;
using MovieManager.Infrustructure.Data;

namespace MovieManager.Infrustructure.Repositories;
internal class ReviewsRepository(MovieContext context)
    : RepositoryBase<Review>(context), IReviewsRepository
{
    public Task<List<Review>> GetAllByMovieIdAsync(int movieId)
    {
        return context.Reviews
            .Where(review => review.MovieId == movieId)
            .AsNoTracking()
            .ToListAsync();
    }
}
