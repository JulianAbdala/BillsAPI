namespace RatingAPI.Models
{
    public class BillsDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public long CUIT { get; set; }
        public string? Descripcion { get; set; }
        public long Precio { get; set; }
    }
}