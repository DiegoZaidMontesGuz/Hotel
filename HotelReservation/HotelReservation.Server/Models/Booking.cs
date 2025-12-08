namespace HotelReservation.Server.Models
{
    public class Booking
    {
        public int hotelNo { get; set; }
        public int guestNo { get; set; }
        public DateTime dateFrom { get; set; }
        public DateTime dateTo { get; set; }
        public int roomNo { get; set; }
    }
}
