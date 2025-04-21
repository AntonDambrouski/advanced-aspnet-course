using HotelManagerApi.Entities;

namespace reviewManagerApi.Services;

public class ReviewService : IReviewService
{
    private static readonly List<Review> _reviews = [];

    public void AddReview(Review review)
    {
        _reviews.Add(review);
    }

    public void DeleteReview(int id)
    {
        var review = _reviews.FirstOrDefault(r => r.Id == id);
        if (review != null)
        {
            _reviews.Remove(review);
        }
    }

    public Review GetReview(int id)
    {
        return _reviews.FirstOrDefault(r => r.Id == id);
    }

    public List<Review> GetAllReviews()
    {
        return _reviews;
    }

    public void UpdateReview(int id, Review UpdateReview)
    {
        var review = _reviews.FirstOrDefault(r => r.Id == id);
        if (review != null)
        {
            review.Reviewer = UpdateReview.Reviewer;
            review.Rating = UpdateReview.Rating;
            review.ReviewText = UpdateReview.ReviewText;
            review.HotelId = UpdateReview.HotelId;

        }
    }

    public List<Review> GetReviewsByHotelId(int hotelId)
    {
        return _reviews.Where(h=>h.HotelId == hotelId).ToList();
    }
}
