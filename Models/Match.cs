using System.ComponentModel.DataAnnotations;

namespace LolFantasy.Models
{
    public class Match
    {
        // Match Attributes 
        [Key]
        public int MatchId { get; set; } // Unique Identifier of particular match
        public int MatchType { get; set; } // Regular game | Semi finals | Finals etc.
        [Required]
        public DateOnly MatchDate { get; set; } // When the Game was played
        [Required]
        public int HomeTeamId { get; set; } // Id of the home team
        [Required]
        public int AwayTeamId { get; set; } // Id of the away team
        public bool GameComplete { get; set; } // Whether game game has been played or not. Can show default values if not played.
        public int WinnerTeamId { get; set; } // Id of the winning team so information displays correctly.

    }
}
