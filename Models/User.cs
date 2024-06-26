﻿using LolFantasy.Models.Dto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LolFantasy.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdateTime { get; set; }


        public UserDto ConvertToDto()
        {
            return new UserDto
            (
                Id,
                FirstName,
                LastName,
                Email,
                PhoneNumber,
                PhotoUrl
            );            
        }
    }
}
