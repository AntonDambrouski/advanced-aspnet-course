using HotelManager.Models;

namespace HotelManager.Services
{
    public interface IHotelManagerService
    {
        void AddHotel(Hotel hotel);
        void DeleteHotel(int id);
        Hotel? GetHotelById(int id);
        List<Hotel> GetHotels();
        void UpdateHotel(Hotel hotel);
    }
}