using System.ComponentModel.DataAnnotations;

namespace RatingAPI.Models
{
        public class PostBillsDto


        {
            [Required(ErrorMessage = "Agregá un nombre")]
            [MaxLength(50)]
            public string Nombre { get; set; } = string.Empty;
            [Required(ErrorMessage = "Agregá el CUIT")]
            public long CUIT { get; set; }
            [MaxLength(300)]
            [Required(ErrorMessage = "Agregá una descripcion")]
            public string? Descripcion { get; set; }
            [Required(ErrorMessage = "Agregá el precio")]
            public long Precio { get; set; }
        }
}