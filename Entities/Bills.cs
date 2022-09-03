using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// Agregar mas items a Bills: Se ponen debajo lo que se agrega, Consola, add-migration + nombre descriptivo.
namespace RatingAPI.Entities

{
    public class Bills
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Ya no se necesita el maxId
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public long CUIT { get; set; }
        [Required]
        public string? Descripcion { get; set; }
        [Required] 
        public long Precio { get; set; }

        public Bills(string nombre)
        {
            Nombre = nombre;
        }
    }
}
