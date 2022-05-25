using TeamsAPI.Models;
using TeamsAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using TeamsAPI.DAL;

namespace TeamsAPI.Repositories
{
    public class PlayersRepo : Repository<Player>, IPlayersRepo
    {
        public PlayersRepo(Context context) : base(context)
        {
        }
        //Get Players by ID
        public async Task<List<Player>> GetPlayerByIdAsync(int? id)
        {
            if(id != null)
            {
                return await GetAll().Where(x => x.id == id).ToListAsync();
            }
            else
            {
                return null;
            }
            
        }
        //Get All Players
        public async Task<List<Player>> GetAllPlayersAsync()
        {
            return await GetAll().ToListAsync();
        }
        //Get Players by last name
        public async Task<List<Player>> GetAllPlayersbyLastNameAsync(string? lastName)
        {
            if(lastName != null)
            {
                return await GetAll().Where(x => x.lastName == lastName).ToListAsync();
            }
            else
            {
                return null;
            }
            
        }
        //Get Players by Team ID
        public async Task<List<Player>> GetAllPlayersbyTeamAsync(int? teamId)
        {
            if(teamId != null)
            {
                return await GetAll().Where(x => x.Teamid == teamId).ToListAsync();
            }
            else
            {
                return null;
            }   
        }
        //Update a player
        public async Task<Player> UpdatePlayerAsync(int id, Player player)
        {
            var savedPlayer = GetAll().Where(x => x.id == id).FirstOrDefault();
            if (savedPlayer != null)
            {
                savedPlayer.firstName = player.firstName;
                savedPlayer.lastName = player.lastName;
                savedPlayer.Teamid = player.Teamid;
                return await UpdateAsync(savedPlayer);
            }
            else
            {
                return null;
            }
        }
        //Delete Player
        public async Task<Player>  DeletePlayerAsync(int id)
        {
            var playerModel = GetAll().FirstOrDefault(x => x.id == id);

            if (playerModel != null)
            {

                return await RemoveAsync(playerModel);
            }
            else
            {
                return null;
            }
        }
    }
}
