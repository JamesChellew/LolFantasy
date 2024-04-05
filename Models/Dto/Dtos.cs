using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace LolFantasy.Models.Dto
{
    public record UserDto(
        int Id,
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber,
        string PhotoUrl
        )
    {
        public User ConvertToUser()
        {
            return new User
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                PhoneNumber = PhoneNumber,
                PhotoUrl = PhotoUrl
            };
        }
    }


    public record PlayerDto(
        int PlayerId,
        string InGameName,
        string FullName,
        string Role,
        int Kills,
        int Deaths,
        int Assists,
        int CreepScore
        )
    {
        public Players ConvertToPlayers()
        {
            return new Players
            {
                PlayerId = PlayerId,
                InGameName = InGameName,
                FullName = FullName,
                Role = Role,
                Kills = Kills,
                Deaths = Deaths,
                Assists = Assists,
                CreepScore = CreepScore
            };
        }
    }

    public record TeamDto(
        [Required] int TeamId,
        [Required] string TeamName,
        List<int> PlayerIdList
        )
    {
        public Team ConvertToTeam()
        {
            return new Team
            {
                TeamId = TeamId,
                TeamName = TeamName,
                PlayerIdList = PlayerIdList
            };
        }
    }
}
