using HotelReservation.Server.DAL;
using HotelReservation.Server.Models;

namespace HotelReservation.Server.BLL
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepo;

        public HotelService(IHotelRepository hotelRepo)
        {
            _hotelRepo = hotelRepo;
        }

        public Task<int> CreateHotelAsync(Hotel hotel)
        {
            if (string.IsNullOrWhiteSpace(hotel.hotelName))
                throw new ArgumentException("Hotel name is required");
            return _hotelRepo.AddHotelAsync(hotel);
        }
    }
}
