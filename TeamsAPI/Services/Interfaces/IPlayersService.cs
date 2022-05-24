using TeamsAPI.Models;

namespace TeamsAPI.Services.Interfaces
{
    public interface IPlayersService
    {
        Task<List<Player>> GetAllPlayersService(int? id, string? lastName, int? teamId);
        Task<Player> UpdatePlayer(int id, Player player);
        Task<Player> AddPlayerAsync(Player player);
        Task<Player> DeletePlayerAsync(int id);

    }
}
