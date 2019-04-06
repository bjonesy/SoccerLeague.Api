using MongoDB.Driver;
using SoccerLeague.DataAccess.Models;

namespace SoccerLeague.DataAccess.Models
{
    public interface ITeamContext
    {
        IMongoCollection<TeamModel> Teams { get; }
    }
}