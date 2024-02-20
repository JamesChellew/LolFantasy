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
        public UserController()
        {
        }

        [HttpGet] // Get endpoint when no parameters are passed]
        [ProducesResponseType(StatusCodes.Status200OK)] // The type here is not needed if specified in the return type of the method.
        public ActionResult<IEnumerable<UserDTO>> GetUsers()
        {
            //logger.Log("Getting List of Users", "information");
            return Ok(UserStore.userList);
        }

        // Get endpoint when "id" parameter is passed. Must specify what information is needed in the HttpGet or else the program will not know which endpoint to use.\
        // Name = "GetUser" Gives the Endpoint an explicit name so we can call it later
        [HttpGet("{id:int}", Name = "GetUser")] 
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDTO))] // The type here is not needed if specified in the return type of the method.
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDTO> GetUser(int id)
        {
            if (id <= 0)
            {
                //logger.Log($"User Id:{id} is a bad request", "error");
                return BadRequest();
            }
            var user = UserStore.userList.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                //logger.Log($"Cannot find user with ID:{id}", "error");
                return NotFound();
            }
            //logger.Log($"Getting information for user ID:{id}", "information");
            return Ok(user);
        }

        [HttpPost(Name = "PostUser")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDTO))] // The type here is not needed if specified in the return type of the method.
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UserDTO> CreateUser(UserDTO userDTO)
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
            userDTO.Id = UserStore.userList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            UserStore.userList.Add(userDTO);
            return CreatedAtRoute("GetUser", new { id = userDTO.Id }, userDTO);
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
            var user = UserStore.userList.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            UserStore.userList.Remove(user);
            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateUser(int id, [FromBody]UserDTO userDTO)
        {
            if (userDTO == null || id != userDTO.Id)
            {
                return BadRequest();
            }
            var userToBeUpdated = UserStore.userList.FirstOrDefault(u =>u.Id == id);
            if (userToBeUpdated == null)
            {
                return NotFound(userDTO.Id);
            }
            userToBeUpdated.FirstName = userDTO.FirstName;
            return NoContent();
        }

        [HttpPatch("id:int", Name = "PatchUser")]
        public IActionResult PatchUser(int id, JsonPatchDocument<UserDTO> patchDTO)
        {
            if (patchDTO == null || id <= 0)
            {
                return BadRequest();
            }
            var userToBePatched = UserStore.userList.FirstOrDefault(u =>u.Id == id);
            if (userToBePatched == null)
            {
                return NotFound();
            }
            // patchDTO is a JsonPatchDocument, we want to apply that patch to the userToBeUpdated, storing any errors in the ModelState.
            patchDTO.ApplyTo(userToBePatched, ModelState);
            if (!ModelState.IsValid) 
            { 
                return BadRequest(ModelState);
            }
            return NoContent(); 
        }

    }
}
