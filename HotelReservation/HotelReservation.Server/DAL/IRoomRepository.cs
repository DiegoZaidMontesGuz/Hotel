

using HotelReservation.Server.Models;

namespace HotelReservation.Server.DAL
{
    public interface IRoomRepository
    {
        Task<int> AddRoomAsync(Room room);
    }
}
