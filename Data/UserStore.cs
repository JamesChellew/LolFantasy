
using LolFantasy.Models.Dto;

namespace LolFantasy.Data
{
    public class UserStore
    {
        public static List<UserDTO> userList = new List<UserDTO>
        {
            new UserDTO {
                Id = 1,
                FirstName = "Test",
                LastName = "Test"
            }
        };
    }
}
