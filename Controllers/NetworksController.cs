using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GesParck.Data;
using GesParck.Models;

namespace GesPark.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NetworksController : ControllerBase
    {
        private readonly GesParckContext _context;

        public NetworksController(GesParckContext context)
        {
            _context = context;
        }

        // GET: api/Networks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Network>>> GetNetwork()
        {
            return await _context.Network.ToListAsync();
        }

        // GET: api/Networks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Network>> GetNetwork(int id)
        {
            var network = await _context.Network.FindAsync(id);

            if (network == null)
            {
                return NotFound();
            }

            return network;
        }

        // PUT: api/Networks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNetwork(int id, Network network)
        {
            if (id != network.NetworkId)
            {
                return BadRequest();
            }

            _context.Entry(network).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NetworkExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Networks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Network>> PostNetwork(Network network)
        {
            _context.Network.Add(network);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNetwork", new { id = network.NetworkId }, network);
        }

        // DELETE: api/Networks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNetwork(int id)
        {
            var network = await _context.Network.FindAsync(id);
            if (network == null)
            {
                return NotFound();
            }

            _context.Network.Remove(network);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NetworkExists(int id)
        {
            return _context.Network.Any(e => e.NetworkId == id);
        }
    }
}
