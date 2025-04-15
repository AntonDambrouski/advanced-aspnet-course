using HotelManager.Models;
using HotelManager.Storages;

namespace HotelManager.Services;

public class ReviewManagerService : IReviewManagerService
{
    private readonly IHotelManagerService _hotelManagerService;

    private readonly IReviewsStorage _reviewsStorage;


    public ReviewManagerService(IHotelManagerService hotelManagerService, IReviewsStorage reviewsStorage)
    {
        _hotelManagerService = hotelManagerService;
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

    public List<Review> GetReviewsByHotelId(int hotelId)
    {
        return _reviewsStorage.GetReviewsByHotelId(hotelId);
    }

    public void AddReviewToHotel(int hotelId, Review review)
    {
        //_reviewsStorage.AddReview
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
