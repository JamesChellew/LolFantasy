using LolFantasy.Models.Dto;

namespace LolFantasy.Data
{
    public static class UserStore
    {
        public static List<UserDTO> userList = new List<UserDTO> {
            new UserDTO { Id = 1, FirstName = "James" },
            new UserDTO{ Id = 2, FirstName = "Liam" },
            new UserDTO{ Id = 3, FirstName = "Jordan" }
            };
    }
}
