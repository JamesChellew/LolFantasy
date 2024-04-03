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
        public User CovertToUser()
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
            public Players ConvertToPlayers( PlayerDto playerDto )
            {
                return new Players
                {
                    PlayerId = playerDto.PlayerId,
                    InGameName = playerDto.InGameName,
                    FullName = playerDto.FullName,
                    Role = playerDto.Role,
                    Kills = playerDto.Kills,
                    Deaths = playerDto.Deaths,
                    Assists = playerDto.Assists,
                    CreepScore = playerDto.CreepScore
                };
            }
        }

    public record TeamDto(
        [Required] int TeamId,
        [Required] string TeamName,
        List<Players> Players
        )
        {
            public Team CovertToTeam(TeamDto teamDto )
            {
                return new Team
                {
                    TeamId = teamDto.TeamId,
                    TeamName = teamDto.TeamName,
                    Players = Players
                };
            }
        }
    public record GameDayDto(
        )


    //{
    //    public int Id { get; set; }
    //    [Required]
    //    [MaxLength(30)]
    //    public string FirstName { get; set; }
    //    [Required]
    //    public string LastName { get; set; }
    //    public string Email { get; set; }
    //    public string PhoneNumber { get; set; }
    //    public string PhotoUrl { get; set; }
    //}
}
