using System.ComponentModel.DataAnnotations;

namespace LolFantasy.Models
{
    public class Players
    {
        [Key] 
        public int PlayerId { get; set; }
        [Required]
        private string InGameName;
        private string FullName;
        private string Role;
        private int Kills;
        private int Deaths;
        private int Assists;
        private int CreepScore;
        private DateTime CreatedTime;
        private DateTime UpdatedTime;
    }
}
