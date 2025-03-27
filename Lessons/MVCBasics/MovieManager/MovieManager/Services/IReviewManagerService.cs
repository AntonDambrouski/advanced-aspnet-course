using MovieManager.Models;

namespace MovieManager.Services;
public interface IReviewManagerService
{
    void AddReview(Review review);
    void AddReviewToMovie(int movieId, Review review);
    List<Review> GetAllReviews();
    Review? GetReviewById(int id);
    List<Review> GetReviewsByMovieId(int movieId);
    void RemoveReview(int reviewId);
    void UpdateReview(int reviewId, Review review);
}