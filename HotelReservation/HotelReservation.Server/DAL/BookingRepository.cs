using System.Data;
using Microsoft.Data.SqlClient;
using HotelReservation.Server.Models;

namespace HotelReservation.Server.DAL
{
    public class BookingRepository : IBookingRepository
    {
        private readonly string _connectionString;

        public BookingRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        public async Task<int> AddBookingAsync(Booking booking)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(@"
                INSERT INTO Booking (hotelNo, roomNo, guestNo, dateFrom, dateTo)
                VALUES (@hotelNo, @roomNo, @guestNo, @dateFrom, @dateTo);
                SELECT SCOPE_IDENTITY();", conn);

            cmd.Parameters.AddWithValue("@hotelNo", booking. hotelNo);
            cmd.Parameters.AddWithValue("@roomNo", booking.roomNo);
            cmd.Parameters.AddWithValue("@guestId", booking.guestNo);
            cmd.Parameters.AddWithValue("@dateFrom", booking.dateFrom);
            cmd.Parameters.AddWithValue("@dateTo", booking.dateTo);

            await conn.OpenAsync();
            var result = await cmd.ExecuteScalarAsync();
            return Convert.ToInt32(result);
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            var bookings = new List<Booking>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("SELECT hotelNo, roomNo, guestNo, dateFrom, dateTo FROM Booking", conn);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                bookings.Add(new Booking
                {
                    hotelNo = reader.GetInt32(1),
                    roomNo = reader.GetInt32(2),
                    guestNo = reader.GetInt32(3),
                    dateFrom = reader.GetDateTime(4),
                    dateTo = reader.GetDateTime(5)
                });
            }

            return bookings;
        }
    }
}
