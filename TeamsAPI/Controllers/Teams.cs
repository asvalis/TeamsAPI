using Microsoft.AspNetCore.Mvc;
using TeamsAPI.Models;
using TeamsAPI.Services.Interfaces;

namespace TeamsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Teams : ControllerBase
    {
        private readonly ITeamsService teamsService;

        public Teams(ITeamsService teamsService)
        {
            this.teamsService = teamsService;
        }

        // GET 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams(int? id = null, string? orderBy = null)
        {
            if (teamsService != null)
            {
                var result = await teamsService.GetAllTeamsService(id, orderBy);

                if(result != null)
                {
                    return result;
                }
                else
                {
                    return BadRequest("Not a valid Order By. Available: name, location.");
                }  
            }
            else
            {
                return Problem("Service 'TeamsService' is null.");
            }
            
        }

        // POST 
        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam([FromBody] Team team)
        {
            if (teamsService != null)
            {
                var addedTeam = await teamsService.AddTeamAsync(team);

                if (addedTeam != null)
                {
                    return Created("Created", team);
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
    }
}
