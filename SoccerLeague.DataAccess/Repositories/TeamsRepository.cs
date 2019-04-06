
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using SoccerLeague.DataAccess.Models;

namespace SoccerLeague.DataAccess.Repositories
{
    public class TeamsRepository : ITeamRepository
    {
        private readonly ITeamContext _context;

        public TeamsRepository(ITeamContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TeamModel>> GetAllTeams()
        {
            return await _context
                            .Teams
                            .Find(_ => true)
                            .ToListAsync();
        }

        public Task<TeamModel> GetTeam(string name)
        {
            FilterDefinition<TeamModel> filter = Builders<TeamModel>.Filter.Eq(m => m.Name, name);

            return _context
                    .Teams
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public async Task Create(TeamModel team)
        {
            await _context.Teams.InsertOneAsync(team);
        }

        public async Task<bool> Update(TeamModel team)
        {
            ReplaceOneResult updateResult =
                await _context
                        .Teams
                        .ReplaceOneAsync(
                            filter: g => g.Id == team.Id,
                            replacement: team);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string name)
        {
            FilterDefinition<TeamModel> filter = Builders<TeamModel>.Filter.Eq(m => m.Name, name);

            DeleteResult deleteResult = await _context
                                                .Teams
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}