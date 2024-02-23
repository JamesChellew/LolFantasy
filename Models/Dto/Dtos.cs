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
        );

    public record PlayerDto(
        int PlayerId,
        string InGameName,
        string FullName,
        string Role,
        int Kills,
        int Deaths,
        int Assists,
        int CreepScore
        );

    public record TeamDto(
        [Required] int TeamId,
        [Required] string TeamName,
        List<Players> Players
        );

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
