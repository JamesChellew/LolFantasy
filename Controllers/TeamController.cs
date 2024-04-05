using LolFantasy.Data;
using LolFantasy.Models;
using LolFantasy.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace LolFantasy.Controllers
{
    [Route("api/TeamAPI")]
    [ApiController]
    public class TeamController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TeamController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: api/TeamAPI/GetTeams
        [HttpGet(Name = "GetTeams")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Team>> GetAllTeams()
        {
            var allTeams = _db.Teams.ToList();
            var allTeamsDto = new List<TeamDto>();
            foreach (Team t in allTeams)
            {
                allTeamsDto.Add(t.ConvertToTeamDto());
            }
            return Ok(allTeamsDto);
        }

        // GET: api/TeamAPI/GetTeam/{int}
        [HttpGet("{int}", Name = "GetTeam")]
        public ActionResult<IEnumerable<TeamDto>> GetTeam(int teamId)
        {
            if (teamId < 0)
            {
                return BadRequest();
            }
            Team team = _db.Teams.FirstOrDefault(t => t.TeamId == teamId);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }

        // POST: api/TeamAPI/CreateTeam
        [HttpPost(Name = "CreateTeam")]
        public ActionResult CreateTeam(TeamDto teamDto)
        {
            if (teamDto == null)
            {
                return BadRequest();
            }
            if (teamDto.TeamId > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            Team team = teamDto.ConvertToTeam();
            _db.Teams.Add(team);
            _db.SaveChanges();
            return Ok();
        }

        // PUT: api/TeamAPI/UpdateTeam/{int}
        [HttpPut("{int}", Name = "UpdateTeam")]
        public ActionResult UpdateTeam(int teamId, TeamDto teamDto)
        {
            if (teamDto == null || teamId != teamDto.TeamId)
            {
                return BadRequest();
            }
            var teamToBeUpdated = _db.Teams.FirstOrDefault(t => t.TeamId == teamId);
            if (teamToBeUpdated == null)
            {
                return NotFound(teamId);
            }
            var team = teamDto.ConvertToTeam();
            _db.Teams.Update(team); // _db remembers the index from FirstOrDefault and updates that record.
            _db.SaveChanges();
            return Ok();
        }

        // DELETE: api/TeamAPI/DeleteTeam/{int}
        [HttpDelete("{int}", Name = "DeleteTeam")]
        public ActionResult Delete(int teamId)
        {
            if (teamId > 0)
            {
                return BadRequest();
            }
            var team = _db.Teams.FirstOrDefault(t => t.TeamId == teamId);
            if (team == null)
            {
                return NotFound(teamId);
            }
            _db.Teams.Remove(team);
            _db.SaveChanges();
            return Ok();
        }
    }
}
