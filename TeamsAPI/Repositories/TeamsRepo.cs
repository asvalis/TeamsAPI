using TeamsAPI.Models;
using TeamsAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using TeamsAPI.DAL;

namespace TeamsAPI.Repositories
{
    public class TeamsRepo : Repository<Team>, ITeamsRepo
    {
        public TeamsRepo(Context context) : base(context)
        {
        }

        //Get teams by id
        public async Task<List<Team>> GetTeamByIdAsync(int? id)
        {
            if (id != null)
            {
                return await GetAll().Include(x => x.players).Where(x => x.players.Any(y => y.Teamid == x.id)).Where(x => x.id == id).ToListAsync();
            }
            else
            {
                return null;
            }
        }
        //Get all teams
        public async Task<List<Team>> GetAllTeamsAsync(string? orderBy)
        {
            if (orderBy == null)
            {
                return await GetAll().Include(x => x.players).Where(x => x.players.Any(y => y.Teamid == x.id)).ToListAsync();
            }
            else
            {
                if(orderBy.ToLower() == "name")
                {
                    return await GetAll().OrderBy(x => x.name).Include(x => x.players).Where(x => x.players.Any(y => y.Teamid == x.id)).ToListAsync();
                }
                else if (orderBy.ToLower() == "location")
                {
                    return await GetAll().OrderBy(x => x.location).Include(x => x.players).Where(x => x.players.Any(y => y.Teamid == x.id)).ToListAsync();
                }
                else
                {
                    throw new BadHttpRequestException("Invalid Order By. Supported Order Bys: name, location");
                }
                
            }
        }
    }
}
