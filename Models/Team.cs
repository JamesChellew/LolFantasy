using System.ComponentModel.DataAnnotations;

namespace LolFantasy.Models
{
    public class Team
    {
        [Key]
        private int TeamId { get; set; }
        [Required]
        private string TeamName { get; set; }
        private List<Players> Players { get; set; }
        private DateTime CreatedTime;
        private DateTime UpdatedTime;
    }
}
