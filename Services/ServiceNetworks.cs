using GesPark.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GesPark.Data;

namespace GesPark.Services
{
    

    
        public class ServiceNetwork
    {
            private readonly GesParckContext _context;

            public ServiceNetwork(GesParckContext context)
            {
                _context = context;
            }

            public async Task<List<Network>> GetAllNetworksAsync()
            {
                return await _context.Networks.Include(n => n.Computers).ToListAsync();
            }

            public async Task<Network> GetNetworkByIdAsync(int id)
            {
                return await _context.Networks.Include(n => n.Computers).FirstOrDefaultAsync(n => n.NetworkId == id);
            }

            public async Task<Network> CreateNetworkAsync(Network network)
            {
                _context.Networks.Add(network);
                await _context.SaveChangesAsync();
                return network;
            }

            public async Task<Network> UpdateNetworkAsync(int id, Network network)
            {
                var existingNetwork = await _context.Networks.FindAsync(id);
                if (existingNetwork == null)
                {
                    return null;
                }

                existingNetwork.Name = network.Name;
                existingNetwork.Description = network.Description;
                existingNetwork.MACAddress = network.MACAddress;
                existingNetwork.Speed = network.Speed;
                existingNetwork.DefaultIPGateway = network.DefaultIPGateway;
                existingNetwork.ComputerId = network.ComputerId;

                await _context.SaveChangesAsync();
                return existingNetwork;
            }

            public async Task<bool> DeleteNetworkAsync(int id)
            {
                var network = await _context.Networks.FindAsync(id);
                if (network == null)
                {
                    return false;
                }

                _context.Networks.Remove(network);
                await _context.SaveChangesAsync();
                return true;
            }

            // Example of an additional functionality: Get Networks by Computer
            public async Task<List<Network>> GetNetworksByComputerAsync(int computerId)
            {
                return await _context.Networks.Where(n => n.ComputerId == computerId).ToListAsync();
            }
        }
    

}
