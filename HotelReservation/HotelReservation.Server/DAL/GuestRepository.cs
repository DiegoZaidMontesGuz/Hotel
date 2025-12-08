using System.Data;
using Microsoft.Data.SqlClient;
using HotelReservation.Server.Models;

namespace HotelReservation.Server.DAL
{
    public class GuestRepository : IGuestRepository
    {
        private readonly string _connectionString;

        public GuestRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        public async Task<int> AddGuestAsync(Guest guest)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(@"
            INSERT INTO Hotel (guestNo, guestName, guestAddress)
            VALUES (@guestNo, @guestName, @guestAddress);
            SELECT SCOPE_IDENTITY();", conn);

            cmd.Parameters.AddWithValue("@hotelNo", guest.guestNo);
            cmd.Parameters.AddWithValue("@hotelName", guest.guestName);
            cmd.Parameters.AddWithValue("@City", guest.guestAddress);

            await conn.OpenAsync();
            var result = await cmd.ExecuteScalarAsync();
            return Convert.ToInt32(result);
        }
    }
}
