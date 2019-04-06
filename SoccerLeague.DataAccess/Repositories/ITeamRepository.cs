
using System.Collections.Generic;
using System.Threading.Tasks;
using SoccerLeague.DataAccess.Models;

namespace SoccerLeague.DataAccess.Repositories
{
    public interface ITeamRepository
    {
        Task<IEnumerable<TeamModel>> GetAllTeams();
        Task<TeamModel> GetTeam(string name);
        Task Create(TeamModel team);
        Task<bool> Update(TeamModel team);
        Task<bool> Delete(string name);
    }
}