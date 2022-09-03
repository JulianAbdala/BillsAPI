using RatingAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace RatingAPI.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public string? Name { get; set; }
        [MaxLength(20)]
        public string? SurName { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        public string UserName { get; set; }
        public Permissions UserType { get; set; }

    }
}
