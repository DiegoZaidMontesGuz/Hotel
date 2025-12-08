

using HotelReservation.Server.BLL;
using HotelReservation.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        // POST api/bookings
        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] Booking booking)
        {
            try
            {
                var No = await _bookingService.CreateBookingAsync(booking);
                booking.guestNo = No;
                return CreatedAtAction(nameof(GetAll), new { No }, booking);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetAll()
        {
            var bookings = await _bookingService.GetAllBookingsAsync();
            return Ok(bookings);
        }
    }
}
