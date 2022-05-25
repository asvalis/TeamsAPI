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
            if (newTeam.name != null && newTeam.location != null)
            {
                var teamCheck = teamsRepo.GetAll().Where(x => x.name == newTeam.name).Where(x => x.location == newTeam.location).FirstOrDefault();
                if (teamCheck == null)
                {
                    if (newTeam.players.Count() <= 8)
                    {
                        return await teamsRepo.AddAsync(newTeam);
                    }
                    else
                    {
                        throw new BadHttpRequestException("Only 8 players per team. Selected team already has 8.");
                    }
                }
                else
                {
                    throw new BadHttpRequestException("Team name and location already exist.");
                }
            }
            else
            {
                throw new BadHttpRequestException("Team requires a name and a location.");
            }
            
        }
    }
}
