using HotelManager.Models;

namespace HotelManager.DTOs;

public class HotelWithReviewsDTO
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int NumberOfStars { get; set; }

    public string Address { get; set; }

    public List<ReviewDTO> Reviews { get; set; }

    public double AverageRating { get; set; }
}
