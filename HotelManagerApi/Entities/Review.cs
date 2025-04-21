namespace HotelManagerApi.Entities;

public class Review
{
    public int Id { get; set; }

    public string Reviewer { get; set; } = string.Empty;

    public int Rating { get; set; }

    public string ReviewText { get; set; } = string.Empty;

    public int HotelId { get; set; }
}
