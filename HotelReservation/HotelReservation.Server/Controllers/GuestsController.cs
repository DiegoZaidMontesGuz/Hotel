using HotelReservation.Server.BLL;
using HotelReservation.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestsController : ControllerBase
    {
        private readonly IGuestService _guestService;

        public GuestsController(IGuestService guestService)
        {
            _guestService = guestService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGuest([FromBody] Guest guest)
        {
            var No = await _guestService.CreateGuestAsync(guest);
            guest.guestNo = No;
            return Ok(guest);
        }
    }
}
