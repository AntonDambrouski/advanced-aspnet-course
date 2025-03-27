using MovieManager.Models;

namespace MovieManager.Storages;

public class ReviewsStorage : IReviewsStorage
{
    private static readonly List<Review> _reviews = [];

    public void AddReview(Review review)
    {
        _reviews.Add(review);
    }

    public List<Review> GetReviewsByMovieId(int movieId)
    {
        return _reviews
            .Where(review => review.MovieId == movieId)
            .ToList();
    }

    public Review? GetReviewById(int id)
    {
        return _reviews.FirstOrDefault(review => review.Id == id);
    }

    public void UpdateReview(int reviewId, Review review)
    {
        var existingReview = GetReviewById(reviewId);
        if (existingReview != null)
        {
            existingReview.Rating = review.Rating;
            existingReview.Reviewer = review.Reviewer;
            existingReview.Message = review.Message;
        }
    }

    public void RemoveReview(int reviewId)
    {
        var review = GetReviewById(reviewId);
        if (review != null)
        {
            _reviews.Remove(review);
        }
    }

    public List<Review> GetAllReviews()
    {
        return _reviews;
    }
}
