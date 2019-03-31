using Microsoft.EntityFrameworkCore;
using SoccerLeague.DataAccess.Models;

namespace SoccerLeague.DataAccess
{
    public class TeamContext : DbContext
    {
        public TeamContext(DbContextOptions<TeamContext> options)
            : base(options)
        {
        }

        public DbSet<TeamModel> Teams { get; set; }
    }
}