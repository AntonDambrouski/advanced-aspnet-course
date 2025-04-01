using MovieManager.Models;
using MovieManager.Storages;

namespace MovieManager.Services;

public class ReviewManagerService : IReviewManagerService
{
    private readonly IMovieManagerService _movieManagerService;
    private readonly IReviewsStorage _reviewsStorage;

    public ReviewManagerService([FromKeyedServices("real")] IMovieManagerService movieManagerService, IReviewsStorage reviewsStorage)
    {
        _movieManagerService = movieManagerService;
        _reviewsStorage = reviewsStorage;
    }

    public void AddReview(Review review)
    {
        _reviewsStorage.AddReview(review);
    }

    public List<Review> GetAllReviews()
    {
        return _reviewsStorage.GetAllReviews();
    }

    public List<Review> GetReviewsByMovieId(int movieId)
    {
        return _reviewsStorage.GetReviewsByMovieId(movieId);
    }

    public void AddReviewToMovie(int movieId, Review review)
    {
        //_reviewsStorage.
    }

    public void RemoveReview(int reviewId)
    {
        _reviewsStorage.RemoveReview(reviewId);
    }

    public void UpdateReview(int reviewId, Review review)
    {
        _reviewsStorage.UpdateReview(reviewId, review);
    }

    public Review? GetReviewById(int id)
    {
        return _reviewsStorage.GetReviewById(id);
    }
}
