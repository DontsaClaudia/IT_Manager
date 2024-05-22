using GesPark.Models;
using GesPark.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GesPark.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NetworksController : ControllerBase
    {
        private readonly ServiceNetwork _networkService;

        public NetworksController(ServiceNetwork networkService)
        {
            _networkService = networkService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Network>>> GetAllNetworks()
        {
            var networks = await _networkService.GetAllNetworksAsync();
            return Ok(networks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Network>> GetNetworkById(int id)
        {
            var network = await _networkService.GetNetworkByIdAsync(id);
            if (network == null)
            {
                return NotFound();
            }
            return Ok(network);
        }

        [HttpPost]
        public async Task<ActionResult<Network>> CreateNetwork(Network network)
        {
            var createdNetwork = await _networkService.CreateNetworkAsync(network);
            return CreatedAtAction(nameof(GetNetworkById), new { id = createdNetwork.NetworkId }, createdNetwork);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNetwork(int id, Network network)
        {
            var updatedNetwork = await _networkService.UpdateNetworkAsync(id, network);
            if (updatedNetwork == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNetwork(int id)
        {
            var result = await _networkService.DeleteNetworkAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        // Additional functionality: Get Networks by Computer
        [HttpGet("by-computer/{computerId}")]
        public async Task<ActionResult<List<Network>>> GetNetworksByComputer(int computerId)
        {
            var networks = await _networkService.GetNetworksByComputerAsync(computerId);
            return Ok(networks);
        }
    }
}