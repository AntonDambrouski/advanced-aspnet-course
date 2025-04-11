namespace MovieManager.Core.Entities;

public class Movie : Entity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public List<Review> Reviews { get; set; } = [];
}
