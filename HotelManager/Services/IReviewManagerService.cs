using HotelManager.Models;

namespace HotelManager.Services
{
    public interface IReviewManagerService
    {
        void AddReview(Review review);
        void AddReviewToHotel(int hotelId, Review review);
        List<Review> GetReviewsByHotelId(int hotelId);
        Review? GetReviewById(int id);
        void RemoveReview(int reviewId);
        void UpdateReview(int reviewId, Review review);
        List<Review>? GetAllReviews();
    }
}