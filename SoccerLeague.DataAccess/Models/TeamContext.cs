using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SoccerLeague.DataAccess.Models;

namespace SoccerLeagues.DataAccess.Models
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