using Microsoft.EntityFrameworkCore;
using SoccerLeague.DataAccess.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace SoccerLeague.DataAccess
{
    public class TeamContext : ITeamContext
    {
        private readonly IMongoDatabase _db;

        public TeamContext(IOptions<SettingsModel> options, IMongoClient client)
        {
            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<TeamModel> Teams => _db.GetCollection<TeamModel>("Teams");
  }
}