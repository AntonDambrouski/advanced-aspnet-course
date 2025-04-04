using MovieManagerApi.Entities;

namespace MovieManagerApi.Services;
public interface IReviewsService
{
    void AddReview(Review review);
    void DeleteReview(int id);
    List<Review> GetAllReviews();
    List<Review> GetReviewsByMovieId(int movieId);
    Review GetReview(int id);
    void UpdateReview(int id, Review updatedReview);
}