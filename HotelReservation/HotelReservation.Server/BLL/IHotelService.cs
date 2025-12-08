using HotelReservation.Server.Models;

namespace HotelReservation.Server.BLL
{
    public interface IHotelService
    {
        Task<int> CreateHotelAsync(Hotel hotel);
    }
}
