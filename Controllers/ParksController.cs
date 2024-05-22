using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GesPark.Data;
using GesPark.Models;

namespace GesPark.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParksController : ControllerBase
    {
        private readonly GesParckContext _context;

        public ParksController(GesParckContext context)
        {
            _context = context;
        }

        // GET: api/Parks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parks>>> GetParks()
        {
            return await _context.Parks.ToListAsync();
        }

        // GET: api/Parks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Parks>> GetParks(int id)
        {
            var parks = await _context.Parks.FindAsync(id);

            if (parks == null)
            {
                return NotFound();
            }

            return parks;
        }

        // PUT: api/Parks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParks(int id, Parks parks)
        {
            if (id != parks.Id)
            {
                return BadRequest();
            }

            _context.Entry(parks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParksExists(id))
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

        // POST: api/Parks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Parks>> PostParks(Parks parks)
        {
            _context.Parks.Add(parks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParks", new { id = parks.Id }, parks);
        }

        // DELETE: api/Parks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParks(int id)
        {
            var parks = await _context.Parks.FindAsync(id);
            if (parks == null)
            {
                return NotFound();
            }

            _context.Parks.Remove(parks);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParksExists(int id)
        {
            return _context.Parks.Any(e => e.Id == id);
        }
    }
}
