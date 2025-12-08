using HotelReservation.Server.BLL;
using HotelReservation.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromBody] Room room)
        {
            var No = await _roomService.CreateRoomAsync(room);
            room.roomNo = No;
            return Ok(room);
        }
    }
}
