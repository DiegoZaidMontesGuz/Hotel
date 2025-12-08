using HotelReservation.Server.Models;

namespace HotelReservation.Server.BLL
{
    public interface IBookingService
    {
        Task<int> CreateBookingAsync(Booking booking);
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
    }
}
