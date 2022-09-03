using RatingAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace RatingAPI.Models
{
    public class PostUserDto
    {
        [Required(ErrorMessage = "Agregá un nombre")]
        [MaxLength(20)]
        public string? Name { get; set; }
        [MaxLength(20)]
        public string? SurName { get; set; }
        [Required(ErrorMessage = "Agregue su password con mas de 8 caracteres")]
        [MinLength(8)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Agregue un nick")]
        [MaxLength(20)]
        public string UserName { get; set; }
    }
}
