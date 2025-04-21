using HotelManagerApi.Entities;

namespace HotelManagerApi.Services;

public class HotelService : IHotelService
{
    private static readonly List<Hotel> _hotels = [];

    static HotelService()
    {
        _hotels.Add(new Hotel { Id = 1, Name = "Marriott", Address = "Minsk, Pobediteley avenue", NumberOfStars = 4 });
        _hotels.Add(new Hotel { Id = 2, Name = "Europe", Address = "Minsk, International st.", NumberOfStars = 5 });
        _hotels.Add(new Hotel { Id = 3, Name = "Orbita", Address = "Minsk, Pushkin avenue", NumberOfStars = 3 });
    }

    public void AddHotel(Hotel hotel)
    {
        _hotels.Add(hotel);
    }

    public void DeleteHotel(int id)
    {
        var hotel = _hotels.FirstOrDefault(h => h.Id == id);
        if (hotel != null)
        {
            _hotels.Remove(hotel);
        }
    }

    public Hotel GetHotel(int id)
    {
        return _hotels.FirstOrDefault(h => h.Id == id);
    }

    public List<Hotel> GetAllHotels()
    {
        return _hotels;
    }

    public void UpdateHotel(int id, Hotel UpdateHotel)
    {
        var hotel = _hotels.FirstOrDefault(h => h.Id == id);
        if (hotel != null)
        {
            hotel.Address = UpdateHotel.Address;
            hotel.NumberOfStars = UpdateHotel.NumberOfStars;
            hotel.Name = UpdateHotel.Name;
        }
    }
}
