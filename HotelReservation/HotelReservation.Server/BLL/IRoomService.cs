using HotelReservation.Server.Models;

namespace HotelReservation.Server.BLL
{
    public interface IRoomService
    {
        Task<int> CreateRoomAsync(Room room);
    }
}
