namespace MovieManagerApi.DTOs;

public class CreateReviewDTO
{
    public string Content { get; set; } = string.Empty;
    public int Rating { get; set; }
    public IFormFile File { get; set; }
}
