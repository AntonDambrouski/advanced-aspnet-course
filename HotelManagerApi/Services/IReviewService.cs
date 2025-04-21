using HotelManagerApi.Entities;

namespace reviewManagerApi.Services
{
    public interface IReviewService
    {
        void AddReview(Review review);
        void DeleteReview(int id);
        List<Review> GetAllReviews();
        List<Review> GetReviewsByHotelId(int hotelId);
        Review GetReview(int id);
        void UpdateReview(int id, Review UpdateReview);
    }
}