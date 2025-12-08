using System.Data;
using Microsoft.Data.SqlClient;
using HotelReservation.Server.Models;

namespace HotelReservation.Server.DAL
{
    public class RoomRepository : IRoomRepository
    {
        private readonly string _connectionString;
        public RoomRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        public async Task<int> AddRoomAsync(Room room)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(@"
            INSERT INTO Hotel (roomNo, hotelNo, type, price)
            VALUES (@roomNo, @hotelNo, @type, @price);
            SELECT SCOPE_IDENTITY();", conn);

            cmd.Parameters.AddWithValue("@roomNo", room.roomNo);
            cmd.Parameters.AddWithValue("@hotelNo", room.hotelNo);
            cmd.Parameters.AddWithValue("@type", room.type);
            cmd.Parameters.AddWithValue("@price", room.price);

            await conn.OpenAsync();
            var result = await cmd.ExecuteScalarAsync();
            return Convert.ToInt32(result);
        }
    }
}
