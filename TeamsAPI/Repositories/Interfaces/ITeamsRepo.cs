using TeamsAPI.Models;

namespace TeamsAPI.Repositories.Interfaces
{
    public interface ITeamsRepo : IRepository<Team>
    {
        Task<List<Team>> GetTeamByIdAsync(int? id);
        Task<List<Team>> GetAllTeamsAsync(string? orderBy);
    }
}
