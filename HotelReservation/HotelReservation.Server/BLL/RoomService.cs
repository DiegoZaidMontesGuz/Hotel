using HotelReservation.Server.DAL;
using HotelReservation.Server.Models;

namespace HotelReservation.Server.BLL
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepo;

        public RoomService(IRoomRepository roomRepo)
        {
            _roomRepo = roomRepo;
        }

        public Task<int> CreateRoomAsync(Room room)
        {
            if (string.IsNullOrWhiteSpace(room.type))
                throw new ArgumentException("room type is required");
            return _roomRepo.AddRoomAsync(room);
        }
    }
}
