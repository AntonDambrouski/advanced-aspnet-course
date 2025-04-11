namespace MovieManager.Core.Entities;

public class Review : Entity
{
    public string Content { get; set; } = string.Empty;
    // public Author Author { get; set; } = string.Empty;
    public int Rating { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int MovieId { get; set; }
    public Movie Movie { get; set; } = new Movie();
}
