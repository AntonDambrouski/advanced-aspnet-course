using MovieManager.Models;

namespace MovieManager.Storages;
public interface IReviewsStorage
{
    void AddReview(Review review);
    List<Review> GetAllReviews();
    Review? GetReviewById(int id);
    List<Review> GetReviewsByMovieId(int movieId);
    void RemoveReview(int reviewId);
    void UpdateReview(int reviewId, Review review);
}