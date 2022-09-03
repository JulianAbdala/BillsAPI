using System.ComponentModel.DataAnnotations;
namespace RatingAPI.Models
{
    public class PutBillsDto
    {
        [MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;
        public long CUIT { get; set; }
        [MaxLength(500)]
        public string? Descripcion { get; set; }

        public long Precio { get; set; }
    }
}
