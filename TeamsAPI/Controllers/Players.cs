using Microsoft.AspNetCore.Mvc;
using TeamsAPI.Models;
using TeamsAPI.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;

namespace TeamsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Players : ControllerBase
    {
        private readonly IPlayersService playersService;

        public Players(IPlayersService playersService)
        {
            this.playersService = playersService;
        }

        // GET 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers(int? id = null, string? lastName = null, int? teamId = null)
        {
            if (playersService != null)
            {
                var result = await playersService.GetAllPlayersService(id, lastName, teamId);

                if (result != null)
                {
                    return result;
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return Problem("Service 'PlayerService' is null.");
            }
        }
        // PUT
        [HttpPut]
        public async Task<IActionResult> PutOrders(int id, Player player)
        {
            if (playersService != null)
            {
                var updatedPlayer = await playersService.UpdatePlayer(id, player);

                if (updatedPlayer == null)
                {
                    return NotFound();

                }
                return Ok(updatedPlayer);
            }
            else
            {
                return Problem("Service 'PlayerService' is null.");
            }
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<Player>> PostTeam([FromBody] Player player)
        {
            if (playersService != null)
            {
                var addedTeam = await playersService.AddPlayerAsync(player);

                if (addedTeam != null)
                {
                    return Created("Created", player);
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return Problem("OrderService  is null.");
            }
        }
        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (playersService == null)
            {
                return Problem("OrderService is null.");
            }
            var player = await playersService.DeletePlayerAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            else
            {
                return NoContent();
            }
        }
    }
}
