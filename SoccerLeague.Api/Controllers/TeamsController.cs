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
        private readonly ITeamRepository _repository;

        public TeamsController(ITeamRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Game
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new ObjectResult(await _repository.GetAllTeams());
        }

        // GET: api/Game/name
        [HttpGet("{name}", Name = "Get")]
        public async Task<IActionResult> Get(string name)
        {
            var team = await _repository.GetTeam(name);

            if (team == null)
                return new NotFoundResult();

            return new ObjectResult(team);
        }

        // POST: api/Game
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TeamModel team)
        {
            await _repository.Create(team);
            return new OkObjectResult(team);
        }

        // PUT: api/Game/5
        [HttpPut("{name}")]
        public async Task<IActionResult> Put(string name, [FromBody]TeamModel team)
        {
            var teamFromDb = await _repository.GetTeam(name);

            if (teamFromDb == null)
                return new NotFoundResult();

            team.Id = teamFromDb.Id;

            await _repository.Update(team);

            return new OkObjectResult(team);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            var gameFromDb = await _repository.GetTeam(name);

            if (gameFromDb == null)
                return new NotFoundResult();

            await _repository.Delete(name);

            return new OkResult();
        }
    }
}