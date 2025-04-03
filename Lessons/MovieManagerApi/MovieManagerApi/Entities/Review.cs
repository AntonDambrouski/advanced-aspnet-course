namespace MovieManagerApi.Entities;

public class Review
{
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;
    // public Author Author { get; set; } = string.Empty;
    public int Rating { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int MovieId { get; set; }
}
