using Microsoft.AspNetCore.Mvc;
using TeamsAPI.Models;
using TeamsAPI.Services.Interfaces;

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
                    if (id != null || lastName != null || teamId != null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        return BadRequest();
                    }
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
                if (player.firstName != null && player.lastName != null && player.Teamid != 0)
                {
                    var updatedPlayer = await playersService.UpdatePlayer(id, player);

                    if (updatedPlayer == null)
                    {
                        return NotFound();

                    }
                    else
                    {
                        return Ok(updatedPlayer);
                    }

                }
                else
                {
                    return BadRequest("Missing required fields.");
                }
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
                return Problem("Service 'PlayerService' is null.");
            }
        }
        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (playersService == null)
            {
                return Problem("Service 'PlayerService' is null.");
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
