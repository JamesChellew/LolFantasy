using System.ComponentModel.DataAnnotations;

namespace LolFantasy.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        [Required]
        public string TeamName { get; set; }
        public List<Players> Players { get; set; }
        public DateTime CreatedTime;
        public DateTime UpdatedTime;
    }
}
