using HotelReservation.Server.Models;
using HotelReservation.Server.DAL;

namespace HotelReservation.Server.BLL
{
    public class GuestService : IGuestService
    {
        private readonly IGuestRepository _guestRepo;

        public GuestService(IGuestRepository guestRepo)
        {
            _guestRepo = guestRepo;
        }

        public Task<int> CreateGuestAsync(Guest guest)
        {
            if (string.IsNullOrWhiteSpace(guest.guestName))
                throw new ArgumentException("guest name is required");
            return _guestRepo.AddGuestAsync(guest);
        }
    }
}
