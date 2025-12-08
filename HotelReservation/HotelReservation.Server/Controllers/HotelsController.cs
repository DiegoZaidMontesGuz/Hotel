using HotelReservation.Server.BLL;
using HotelReservation.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotel([FromBody] Hotel hotel)
        {
            var No = await _hotelService.CreateHotelAsync(hotel);
            hotel.hotelNo = No;
            return Ok(hotel);
        }
    }
}
