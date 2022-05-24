using TeamsAPI.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TeamsAPI.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}
