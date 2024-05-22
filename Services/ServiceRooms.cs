using GesPark.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GesPark.Data;

namespace GesPark.Services
{
    public class ServiceRooms
    {
        private readonly GesParckContext _context;

        public ServiceRooms(GesParckContext context)
        {
            _context = context;
        }

        public async Task<List<Rooms>> GetAllRoomsAsync()
        {
            return await _context.Rooms.Include(r => r.Park).Include(r => r.Rule).ToListAsync();
        }

        public async Task<Rooms> GetRoomByIdAsync(int id)
        {
            return await _context.Rooms.Include(r => r.Park).Include(r => r.Rule).FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Rooms> CreateRoomAsync(Rooms room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task<Rooms> UpdateRoomAsync(int id, Rooms room)
        {
            var existingRoom = await _context.Rooms.FindAsync(id);
            if (existingRoom == null)
            {
                return null;
            }

            existingRoom.Name = room.Name;
            existingRoom.ParksId = room.ParksId;
            existingRoom.RulesId = room.RulesId;
            existingRoom.createDate = room.createDate;

            await _context.SaveChangesAsync();
            return existingRoom;
        }

        public async Task<bool> DeleteRoomAsync(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return false;
            }

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
            return true;
        }

        // Example of an additional functionality: Get Rooms by Park
        public async Task<List<Rooms>> GetRoomsByParkAsync(int parkId)
        {
            return await _context.Rooms.Where(r => r.ParksId == parkId).ToListAsync();
        }
    }
}