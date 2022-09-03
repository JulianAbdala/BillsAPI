using RatingAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace RatingAPI.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public Permissions UserType { get; set; }
    }
}
