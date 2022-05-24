using TeamsAPI.Models;

namespace TeamsAPI.Services.Interfaces
{
    public interface ITeamsService
    {
        Task<List<Team>> GetAllTeamsService(int? id, string? orderBy);
        Task<Team> AddTeamAsync(Team team);

    }
}
