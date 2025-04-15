using HotelManager.Models;

namespace HotelManager.Storages;

public class ReviewsStorage : IReviewsStorage
{
    private static readonly List<Review> _reviews = [];

    public void AddReview(Review review)
    {
        _reviews.Add(review);
    }

    public List<Review> GetReviewsByHotelId(int hotelId)
    {
        return _reviews
            .Where(review => review.HotelId == hotelId)
            .ToList();
    }

    public Review? GetReviewById(int id)
    {
        return _reviews.FirstOrDefault(review => review.Id == id);
    }

    public void UpdateReview(int reviewId, Review review)
    {
        var existingReview = GetReviewById(review.Id);
        if (existingReview != null)
        {
            existingReview.Reviewer = review.Reviewer;
            existingReview.Rating = review.Rating;
            existingReview.ReviewText = review.ReviewText;
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
