using GesPark.Models;
using GesPark.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GesPark.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly ServiceRooms _roomService;

        public RoomsController(ServiceRooms roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Rooms>>> GetAllRooms()
        {
            var rooms = await _roomService.GetAllRoomsAsync();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rooms>> GetRoomById(int id)
        {
            var room = await _roomService.GetRoomByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            return Ok(room);
        }

        [HttpPost]
        public async Task<ActionResult<Rooms>> CreateRoom(Rooms room)
        {
            var createdRoom = await _roomService.CreateRoomAsync(room);
            return CreatedAtAction(nameof(GetRoomById), new { id = createdRoom.Id }, createdRoom);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(int id, Rooms room)
        {
            var updatedRoom = await _roomService.UpdateRoomAsync(id, room);
            if (updatedRoom == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var result = await _roomService.DeleteRoomAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        // Additional functionality: Get Rooms by Park
        [HttpGet("by-park/{parkId}")]
        public async Task<ActionResult<List<Rooms>>> GetRoomsByPark(int parkId)
        {
            var rooms = await _roomService.GetRoomsByParkAsync(parkId);
            return Ok(rooms);
        }
    }
}