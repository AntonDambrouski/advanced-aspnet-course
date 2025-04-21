namespace HotelManagerApi.Entities;

public class Hotel
{
    public  int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int NumberOfStars { get; set; } 

    public string Address { get; set; } = string.Empty;
}
