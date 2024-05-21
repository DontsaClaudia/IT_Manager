using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GesParck.Data;
using GesParck.Models;
using GesParck.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GesParck.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComputersController : ControllerBase
    {
        private readonly GesParckContext _computerService;

        public ComputersController(GesParckContext computerService)
        {
            _computerService = computerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Computers>>> GetAllComputers()
        {
            var computers = await _computerService.GetAllComputersAsync();
            return Ok(computers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Computers>> GetComputerById(int id)
        {
            var computer = await _computerService.GetComputerByIdAsync(id);
            if (computer == null)
            {
                return NotFound();
            }
            return Ok(computer);
        }

        [HttpPost]
        public async Task<ActionResult<Computers>> CreateComputer(Computers computer)
        {
            var createdComputer = await _computerService.CreateComputerAsync(computer);
            return CreatedAtAction(nameof(GetComputerById), new { id = createdComputer.Id }, createdComputer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComputer(int id, Computers computer)
        {
            var updatedComputer = await _computerService.UpdateComputerAsync(id, computer);
            if (updatedComputer == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComputer(int id)
        {
            var result = await _computerService.DeleteComputerAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        // Additional functionality: Get Computers by Room
        [HttpGet("by-room/{roomId}")]
        public async Task<ActionResult<List<Computers>>> GetComputersByRoom(int roomId)
        {
            var computers = await _computerService.GetComputersByRoomAsync(roomId);
            return Ok(computers);
        }
    }
}