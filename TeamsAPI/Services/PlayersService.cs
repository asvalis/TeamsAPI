using TeamsAPI.Models;
using TeamsAPI.Services.Interfaces;
using TeamsAPI.Repositories.Interfaces;

namespace TeamsAPI.Services
{
    public class PlayersService : IPlayersService
    {
        private readonly IPlayersRepo playersRepo;

        public PlayersService(IPlayersRepo playersRepo)
        {
            this.playersRepo = playersRepo;
        }
        //Determine how to retrieve players
        public async Task<List<Player>> GetAllPlayersService(int? id, string? lastName, int? teamId)
        {
            if(id != null)
            {
                return await playersRepo.GetPlayerByIdAsync(id);
            }
            else
            {
                if (lastName != null)
                {
                    return await playersRepo.GetAllPlayersbyLastNameAsync(lastName);
                }
                else if (teamId != null)
                {
                    return await playersRepo.GetAllPlayersbyTeamAsync(teamId);
                }
                else
                {
                    return await playersRepo.GetAllPlayersAsync();
                }
            }

        }

        //Update a player
        public async Task<Player> UpdatePlayer(int id, Player player)
        {
            var playerModel = playersRepo.GetAll().Where(x => x.id == id).FirstOrDefault();
            if (playerModel != null)
            {
                if (playerModel.Teamid == player.Teamid)
                {
                    return await playersRepo.UpdatePlayerAsync(id, player);
                }
                else
                {
                    int playerCount = playersRepo.GetAll().Where(x => x.Teamid == player.Teamid).Count();
                    if (playerCount < 8)
                    {
                        return await playersRepo.UpdatePlayerAsync(id, player);
                    }
                    else
                    {
                        throw new BadHttpRequestException("Player can not be updated. Team specified already has 8 players.");
                    }
                }
            }
            else
            {
                throw new BadHttpRequestException("Player specified does not exist.");
            }
        }
        //Add a player. Ensure the target team has less than 8 players
        public async Task<Player> AddPlayerAsync(Player player)
        {
            var playerCheck = playersRepo.GetAll().Where(x => x.firstName == player.firstName).Where(x => x.lastName == player.lastName).FirstOrDefault();
            if (playerCheck == null)
            {
                int playerCount = playersRepo.GetAll().Where(x => x.Teamid == player.Teamid).Count();
                if (playerCount < 8)
                {
                    return await playersRepo.AddAsync(player);
                }
                else
                {
                    throw new BadHttpRequestException("Specified team already has 8 players.");
                }
            }
            else
            {
                throw new BadHttpRequestException("Player already exists.");
            }
        }
        //Delete a player
        public async Task<Player> DeletePlayerAsync(int id)
        {
            return await playersRepo.DeletePlayerAsync(id);
        }
    }
}
