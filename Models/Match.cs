using System.ComponentModel.DataAnnotations;

namespace LolFantasy.Models
{
    public class Match
    {
        // Match Attributes 
        [Key]
        public int MatchId { get; set; }
        public int MatchType { get; set; }
        [Required]
        public DateOnly MatchDate { get; set; }
        [Required]
        public int HomeTeamId { get; set; }
        [Required]
        public int AwayTeamId { get; set; }
        public bool GameComplete { get; set; }
        public int WinnerTeamId { get; set; }
        public List<int> PlayerStatList { get; set; } // Reference to the stats for each player for a particular match
        public List<int> TeamStatList { get; set; } // Reference to the stats for a Team for a particular match
    }
}
