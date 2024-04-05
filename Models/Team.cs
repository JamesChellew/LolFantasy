using LolFantasy.Models.Dto;
using System.ComponentModel.DataAnnotations;

namespace LolFantasy.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        [Required]
        public string TeamName { get; set; }
        public List<int> PlayerIdList { get; set; }
        public DateTime CreatedTime;
        public DateTime UpdatedTime;
        

        public TeamDto ConvertToTeamDto()
        {
            return new TeamDto
                (
                    TeamId,
                    TeamName,
                    PlayerIdList
                );
        }
    }
}
