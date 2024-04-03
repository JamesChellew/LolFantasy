using LolFantasy.Models;
using LolFantasy.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using LolFantasy.Data;
using Microsoft.AspNetCore.JsonPatch;


namespace LolFantasy.Controllers
{
    [Route("api/UserAPI")] // the route that has endpoints on the webserver, like the URL
    [ApiController] // Indicates that the below is a controller
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet] // Get endpoint when no parameters are passed]
        [ProducesResponseType(StatusCodes.Status200OK)] // The type here is not needed if specified in the return type of the method.
        public ActionResult<IEnumerable<UserDto>> GetUsers()
        {
            //logger.Log("Getting List of Users", "information");]

            var users = _db.Users.ToList();
            var userDtos = new List<UserDto>();
            foreach(User u in users)
            {
                userDtos.Add(u.ConvertToDto());
            }
            return Ok(userDtos);
        }

        // Get endpoint when "id" parameter is passed. Must specify what information is needed in the HttpGet or else the program will not know which endpoint to use.\
        // Name = "GetUser" Gives the Endpoint an explicit name so we can call it later
        [HttpGet("{id:int}", Name = "GetUser")] 
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))] // The type here is not needed if specified in the return type of the method.
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDto> GetUser(int id)
        {
            if (id <= 0)
            {
                //logger.Log($"User Id:{id} is a bad request", "error");
                return BadRequest();
            }
            var user = _db.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                //logger.Log($"Cannot find user with ID:{id}", "error");
                return NotFound();
            }
            //logger.Log($"Getting information for user ID:{id}", "information");
            return Ok(user.ConvertToDto());
        }

        [HttpPost(Name = "PostUser")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))] // The type here is not needed if specified in the return type of the method.
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UserDto> CreateUser(UserDto userDTO)
        {
            //if (!ModelState.IsValid) You can use this to explicitly check if the Model state is valid (in UserDTO, the variable for FirstName has a [required] attribute and a character length of 30)
            //{                        We do not need to do this check as the attribute at the top of this class is [ApiController] which does this check automatically.
            //}
            if (userDTO == null)
            {
                return BadRequest();
            }
            if (userDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var user = userDTO.CovertToUser();
            user.CreatedTime = DateTime.Now;
            user.UpdateTime = DateTime.Now;
            _db.Users.Add(user);
            _db.SaveChanges();
            //return CreatedAtRoute("GetUser", new { id = userDTO.Id }, userDTO);
            return Ok();
        }

        [HttpDelete("{id:int}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteUser(int id) // we do not want to return any data when deleting. IActionResult does not specify a return type along with the action result
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var user = _db.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            _db.Users.Remove(user);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateUser(int id, [FromBody]UserDto userDto)
        {
            if (userDto == null || id != userDto.Id)
            {
                return BadRequest();
            }
            var userToBeUpdated = _db.Users.FirstOrDefault(u => u.Id == id);
            if (userToBeUpdated == null)
            {
                return NotFound(id);
            }
            // TODO: Make a method for transforming Dto to actual class type.
            userToBeUpdated.FirstName = userDto.FirstName;
            userToBeUpdated.LastName = userDto.LastName;
            userToBeUpdated.PhoneNumber = userDto.PhoneNumber;
            userToBeUpdated.Email = userDto.Email;
            userToBeUpdated.PhotoUrl = userDto.PhotoUrl;
            userToBeUpdated.UpdateTime = DateTime.Now;
            _db.Users.Update(userToBeUpdated);
            _db.SaveChanges();
            return Ok(userDto);
        }

        // We can use patch for this but we would need to convert from a User (userToBePatched), to a UserDTO to apply the patch, back to a User to update the Database
        // VERY BAD USE OF CODE.

        //[HttpPatch("id:int", Name = "PatchUser")]
        //public IActionResult PatchUser(int id, JsonPatchDocument<UserDTO> patchDTO)
        //{
        //    if (patchDTO == null || id <= 0)
        //    {
        //        return BadRequest();
        //    }
        //    var userToBePatched = _db.Users.FirstOrDefault(u =>u.Id == id);
        //    if (userToBePatched == null)
        //    {
        //        return NotFound();
        //    }
        //    // patchDTO is a JsonPatchDocument, we want to apply that patch to the userToBeUpdated, storing any errors in the ModelState.
        //    patchDTO.ApplyTo(userToBePatched, ModelState);
        //    if (!ModelState.IsValid) 
        //    { 
        //        return BadRequest(ModelState);
        //    }
        //    return NoContent(); 
        //}

    }
}
