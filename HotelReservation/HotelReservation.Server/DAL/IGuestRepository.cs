using HotelReservation.Server.Models;

namespace HotelReservation.Server.DAL
{
    public interface IGuestRepository
    {
        Task<int> AddGuestAsync(Guest guest);
    }

}