using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SoccerLeague.DataAccess.Models
{
    public class TeamModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public string CrestUrl { get; set; }
    }
}