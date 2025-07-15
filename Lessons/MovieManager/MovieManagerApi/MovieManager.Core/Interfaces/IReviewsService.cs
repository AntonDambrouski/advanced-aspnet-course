using MovieManager.Core.Entities;

namespace MovieManager.Core.Interfaces;
public interface IReviewsService
{
    void AddReview(Review review);
    void DeleteReview(int id);
    List<Review> GetAllReviews();
    List<Review> GetReviewsByMovieId(int movieId);
    Review GetReview(int id);
    void UpdateReview(int id, Review updatedReview);
}