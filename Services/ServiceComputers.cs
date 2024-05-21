using GesParck.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GesParck.Services
{
    public class ComputerService
    {
        private readonly ApplicationDbContext _context;

        public ComputerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Computers>> GetAllComputersAsync()
        {
            return await _context.Computers.Include(c => c.Room).Include(c => c.position).ToListAsync();
        }

        public async Task<Computers> GetComputerByIdAsync(int id)
        {
            return await _context.Computers.Include(c => c.Room).Include(c => c.position).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Computers> CreateComputerAsync(Computers computer)
        {
            _context.Computers.Add(computer);
            await _context.SaveChangesAsync();
            return computer;
        }

        public async Task<Computers> UpdateComputerAsync(int id, Computers computer)
        {
            var existingComputer = await _context.Computers.FindAsync(id);
            if (existingComputer == null)
            {
                return null;
            }

            existingComputer.Manufacturer = computer.Manufacturer;
            existingComputer.Model = computer.Model;
            existingComputer.Caption = computer.Caption;
            existingComputer.Name = computer.Name;
            existingComputer.TotalPhysicalMemory = computer.TotalPhysicalMemory;
            existingComputer.MappingId = computer.MappingId;
            existingComputer.RoomId = computer.RoomId;

            await _context.SaveChangesAsync();
            return existingComputer;
        }

        public async Task<bool> DeleteComputerAsync(int id)
        {
            var computer = await _context.Computers.FindAsync(id);
            if (computer == null)
            {
                return false;
            }

            _context.Computers.Remove(computer);
            await _context.SaveChangesAsync();
            return true;
        }

        // Example of an additional functionality: Get Computers by Room
        public async Task<List<Computers>> GetComputersByRoomAsync(int roomId)
        {
            return await _context.Computers.Where(c => c.RoomId == roomId).ToListAsync();
        }
    }
}