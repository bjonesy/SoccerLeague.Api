using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoccerLeague.DataAccess.Models;
using SoccerLeague.DataAccess.Repositories;

namespace SoccerLeague.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly TeamsRepository _repository;

        public TeamsController(TeamsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TeamModel>> GetByIdAsync(int id)
        {
            var team = await _repository.GetTeamAsync(id);

            #region snippet_ProblemDetailsStatusCode
            if (team == null)
            {
                return NotFound();
            }
            #endregion

            return team;
        }

        [HttpGet]
        public async Task<ActionResult<List<TeamModel>>> GetAsync()
        {
            List<TeamModel> teams = null;

            teams = await _repository.GetTeamsAsync();

            return teams;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TeamModel>> CreateAsync(TeamModel team)
        {
            await _repository.AddTeamAsync(team);

            return CreatedAtAction(nameof(GetByIdAsync),
                new { id = team.Id }, team);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _repository.DeleteTeamAsync(id);

            return StatusCode(200);
        }
    }
}