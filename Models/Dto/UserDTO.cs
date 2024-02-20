using System.ComponentModel.DataAnnotations;

namespace LolFantasy.Models.Dto
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
    }
}
