using LolFantasy.Data;
using LolFantasy.Models;
using LolFantasy.Models.Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LolFantasy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {

        public readonly ApplicationDbContext _db;

        public PlayersController (ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: api/<PlayersController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<PlayerDto>> GetAllPlayers()
        {
            var players = _db.Players.ToList();
            var playersDto = new List<PlayerDto>();
            foreach (var player in players)
            {
                playersDto.Add(player.ToPlayerDto());
            }
            return Ok(playersDto);
        }

        // GET api/<PlayersController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PlayerDto> GetPlayer(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            var player = _db.Players.FirstOrDefault(p => p.PlayerId == id);
            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }

        // POST api/<PlayersController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreatePlayer(PlayerDto playerDto)
        {
            if (playerDto == null)
            {
                return BadRequest();
            }
            Players player = new()
            {
                InGameName = playerDto.InGameName,
                FullName = playerDto.FullName,
                Role = playerDto.Role,
                Kills = playerDto.Kills,
                Deaths = playerDto.Deaths,
                Assists = playerDto.Assists,
                CreepScore = playerDto.CreepScore,
            };
            // Makes sure the players object was created correctly.
            if(player == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            _db.Players.Add(player); // do not need to assign an id as EF will do that for us.
            _db.SaveChanges();
            return Ok();
        }

        // PUT api/<PlayersController>/5
        [HttpPut("{id}")]
        public IActionResult Upadateplayer(int id, [FromBody] PlayerDto playerDto)
        {
            if (id != playerDto.PlayerId || id < 0)
            {
                return BadRequest();
            }
            var player = _db.Players.FirstOrDefault(p => p.PlayerId == id);
            if (player == null)
            {
                return NotFound(id);
            }
            // TODO: need to make a method for this
            player.InGameName = playerDto.InGameName;
            player.FullName = playerDto.FullName;
            player.Role = playerDto.Role;
            player.Kills = playerDto.Kills;
            player.Deaths = playerDto.Deaths;
            player.Assists = playerDto.Assists;
            player.CreepScore = playerDto.CreepScore;
            player.UpdatedTime = DateTime.Now;

            _db.Players.Update(player);
            _db.SaveChanges(); 
            return Ok();

        }
        
        // DELETE api/<PlayersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            var player = _db.Players.FirstOrDefault(p => p.PlayerId == id);
            if (player == null)
            {
                return NotFound(id);
            }
            _db.Players.Remove(player);
            _db.SaveChanges();
            return Ok();
        }
    }
}
