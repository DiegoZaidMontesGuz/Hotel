namespace HotelReservation.Server.Models
{
    public class Room
    {
        public int roomNo { get; set; }
        public int hotelNo { get; set; }
        public string type { get; set; } = "";
        public int price { get; set; }
    }
}
