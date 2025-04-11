using MovieManager.Core.Entities;
using MovieManager.Core.Interfaces;

namespace MovieManager.Core.Services;

public class ReviewsService : IReviewsService
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

    public void UpdateReview(int id, Review updatedReview)
    {
        var review = _reviews.FirstOrDefault(r => r.Id == id);
        if (review != null)
        {
            review.Content = updatedReview.Content;
            review.Rating = updatedReview.Rating;
            review.CreatedAt = updatedReview.CreatedAt;
            review.MovieId = updatedReview.MovieId;
        }
    }

    public List<Review> GetReviewsByMovieId(int movieId)
    {
        return _reviews.Where(r => r.MovieId == movieId).ToList();
    }
}
