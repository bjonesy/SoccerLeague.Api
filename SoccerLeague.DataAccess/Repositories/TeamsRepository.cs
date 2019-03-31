
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoccerLeague.DataAccess.Models;

namespace SoccerLeague.DataAccess.Repositories
{
    public class TeamsRepository
    {
        private readonly TeamContext _context;

        public TeamsRepository(TeamContext context)
        {
            _context = context;
        }

        public async Task<List<TeamModel>> GetTeamsAsync()
        {
            return await _context.Teams.ToListAsync();
        }

        public async Task<TeamModel> GetTeamAsync(int id)
        {
            return await _context.Teams.FindAsync(id);
        }

        public async Task<int> AddTeamAsync(TeamModel team)
        {
            int rowsAffected = 0;

            _context.Teams.Add(team);
            rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected;
        }

        public async Task<int> DeleteTeamAsync(int id)
        {

            var deleteTeam = await _context.Teams.FindAsync(id);

            int rowsAffected = 0;

            _context.Teams.Remove(deleteTeam);
            rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected;
        }
    }
}