using HotelReservation.Server.DAL;
using HotelReservation.Server.Models;

namespace HotelReservation.Server.BLL
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepo;

        public BookingService(IBookingRepository bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

        public async Task<int> CreateBookingAsync(Booking booking)
        {
            // Simple business rule example
            if (booking.dateTo <= booking.dateFrom)
                throw new ArgumentException("Check-out date must be after check-in date");

            // add more rules if you want (room availability, etc.)
            return await _bookingRepo.AddBookingAsync(booking);
        }

        public Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return _bookingRepo.GetAllBookingsAsync();
        }
    }
}
