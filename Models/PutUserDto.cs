using RatingAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace RatingAPI.Models
{
    public class PutUserDto
    {
            [Required]
            public string? Name { get; set; } = string.Empty;
            public string? SurName { get; set; }
            [Required]
            public string Password { get; set; }
            [Required]
            public string UserName { get; set; }
            [Required]
            public Permissions UserType { get; set; }
        
    }
}
