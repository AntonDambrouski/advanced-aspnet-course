using MovieManager.Core.Entities;

namespace MovieManager.Core.Interfaces.Repositories;
public interface IReviewsRepository : IRepositoryBase<Review>
{
    Task<List<Review>> GetAllByMovieIdAsync(int movieId);
}
