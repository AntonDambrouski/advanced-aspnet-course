using HotelManagerApi.Entities;

namespace HotelManagerApi.Services
{
    public interface IHotelService
    {
        void AddHotel(Hotel hotel);
        void DeleteHotel(int id);
        List<Hotel> GetAllHotels();
        Hotel GetHotel(int id);
        void UpdateHotel(int id, Hotel UpdateHotel);
    }
}