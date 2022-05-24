using TeamsAPI.Models;
using TeamsAPI.Repositories.Interfaces;
using TeamsAPI.Services.Interfaces;
namespace TeamsAPI.Services
{
    public class TeamsService : ITeamsService
    {
        private readonly ITeamsRepo teamsRepo;

        public TeamsService(ITeamsRepo teamsRepo)
        {
            this.teamsRepo = teamsRepo;
        }
        //Determine how we are retrieving teams
        public async Task<List<Team>> GetAllTeamsService(int? id, string? orderBy)
        {
            if (id != null)
            {
                return await teamsRepo.GetTeamByIdAsync(id);
            }
            else
            {
                return await teamsRepo.GetAllTeamsAsync(orderBy);
            }
        }
        //Add a team
        public async Task<Team> AddTeamAsync(Team newTeam)
        {
            if (newTeam.players.Count() < 8)
            {
                return await teamsRepo.AddAsync(newTeam);
            }
            else
            {
                return null;
            }
            
        }
    }
}
