using System.Data;
using Microsoft.Data.SqlClient;
using HotelReservation.Server.Models;

namespace HotelReservation.Server.DAL
{
    public class HotelRepository : IHotelRepository
    {
        private readonly string _connectionString;

        public HotelRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        public async Task<int> AddHotelAsync(Hotel hotel)
        {
            using var conn = new SqlConnection(_connectionString); 
            using var cmd = new SqlCommand(@"
            INSERT INTO Hotel (hotelNo, hotelName, city)
            VALUES (@hotelNo, @hotelName, @city);
            SELECT SCOPE_IDENTITY();", conn);

            cmd.Parameters.AddWithValue("@hotelNo", hotel.hotelNo);
            cmd.Parameters.AddWithValue("@hotelName", hotel.hotelName);
            cmd.Parameters.AddWithValue("@City", hotel.city);

            await conn.OpenAsync();
            var result = await cmd.ExecuteScalarAsync();
            return Convert.ToInt32(result);
        }
    }
}
