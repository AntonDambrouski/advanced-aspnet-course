using HotelManager.Models;

namespace HotelManager.Services;

public class HotelManagerService : IHotelManagerService
{
    private static readonly List<Hotel> _hotels = [];

    static HotelManagerService()
    {
        _hotels.Add(new Hotel { Id = 1, Name = "Marriott", Address = "Minsk, Pobediteley avenue", NumberOfStars = 4 });
        _hotels.Add(new Hotel { Id = 2, Name = "Europe", Address = "Minsk, International st.", NumberOfStars = 5 });
        _hotels.Add(new Hotel { Id = 3, Name = "Orbita", Address = "Minsk, Pushkin avenue", NumberOfStars = 3 });
    }

    public void AddHotel(Hotel hotel)
    {
        _hotels.Add(hotel);
    }

    public List<Hotel> GetHotels()
    {
        return _hotels;
    }

    public Hotel? GetHotelById(int id)
    {
        return _hotels.FirstOrDefault(h => h.Id == id);
    }

    public void UpdateHotel(Hotel hotel)
    {
        var existingHotel = _hotels.FirstOrDefault(h => h.Id == hotel.Id);
        if (existingHotel != null)
        {
            existingHotel.Name = hotel.Name;
            existingHotel.Address = hotel.Address;
            existingHotel.NumberOfStars = hotel.NumberOfStars;
        }
    }

    public void DeleteHotel(int id)
    {
        var hotel = _hotels.FirstOrDefault(h => h.Id == id);
        if (hotel != null)
        {
            _hotels.Remove(hotel);
        }
    }
}
