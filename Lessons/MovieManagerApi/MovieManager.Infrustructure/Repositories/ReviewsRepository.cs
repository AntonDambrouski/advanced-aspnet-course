using MovieManager.Core.Entities;
using MovieManager.Core.Interfaces.Repositories;
using MovieManager.Infrustructure.Data;

namespace MovieManager.Infrustructure.Repositories;
internal class ReviewsRepository(MovieContext context) 
    : RepositoryBase<Review>(context), IReviewsRepository
{
}
