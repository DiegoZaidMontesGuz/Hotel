using HotelReservation.Server.Models;

namespace HotelReservation.Server.BLL
{
    public interface IGuestService
    {
        Task<int> CreateGuestAsync(Guest guest);
    }
}
