using MovieManager.Models;

namespace MovieManager.DTOs;

public class MovieWithReviewsDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public int Year { get; set; }
    public List<ReviewDTO> Reviews { get; set; }
    public double AverageRating { get; set; }
}
