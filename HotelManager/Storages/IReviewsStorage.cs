using HotelManager.Models;

namespace HotelManager.Storages
{
    public interface IReviewsStorage
    {
        void AddReview(Review review);
        List<Review> GetAllReviews();
        Review? GetReviewById(int id);
        List<Review> GetReviewsByHotelId(int hotelId);
        void RemoveReview(int reviewId);
        void UpdateReview(int reviewId, Review review);
    }
}