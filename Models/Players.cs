using LolFantasy.Models.Dto;
using System.ComponentModel.DataAnnotations;

namespace LolFantasy.Models
{
    public class Players
    {
        [Key] 
        public int PlayerId { get; set; }
        [Required]
        public string InGameName;
        public string FullName;
        public string Role;
        public int TeamId;
        public int Kills;
        public int Deaths;
        public int Assists;
        public int CreepScore;
        public DateTime CreatedTime;
        public DateTime UpdatedTime;


        public PlayerDto ToPlayerDto()
        {
            return new PlayerDto
            (
                PlayerId,
                InGameName,
                FullName,
                Role,
                Kills,
                Deaths,
                Assists,
                CreepScore
            );

        }
    }
}
