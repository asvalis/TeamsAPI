using TeamsAPI.Models;

namespace TeamsAPI.Repositories.Interfaces
{
    public interface IPlayersRepo : IRepository<Player>
    {
        Task<List<Player>> GetPlayerByIdAsync(int? id);
        Task<List<Player>> GetAllPlayersAsync();
        Task<List<Player>> GetAllPlayersbyLastNameAsync(string? lastName);
        Task<List<Player>> GetAllPlayersbyTeamAsync(int? teamId);
        Task<Player> DeletePlayerAsync(int id);
        Task<Player> UpdatePlayerAsync(int id, Player player);
    }
}
