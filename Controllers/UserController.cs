using LolFantasy.Models;
using LolFantasy.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace LolFantasy.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<UserDTO> GetUsers()
        {
            
            return new List<UserDTO>
            {
                new UserDTO { Id = 1, FirstName = "James"},
                new UserDTO { Id = 2, FirstName = "Laim"}

            };
        }
    }
}
