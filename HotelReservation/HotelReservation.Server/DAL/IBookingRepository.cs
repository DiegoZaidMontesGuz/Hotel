using HotelReservation.Server.Models;

namespace HotelReservation.Server.DAL
{
    public interface IBookingRepository
    {
        Task<int> AddBookingAsync(Booking booking);
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
    }
}
