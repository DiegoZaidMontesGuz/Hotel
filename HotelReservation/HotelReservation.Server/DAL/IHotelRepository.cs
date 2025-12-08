using HotelReservation.Server.Models;

namespace HotelReservation.Server.DAL
{
    public interface IHotelRepository
    {
        Task<int> AddHotelAsync(Hotel hotel);

    }
}
