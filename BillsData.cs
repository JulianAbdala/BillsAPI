using RatingAPI.Models;

namespace RatingAPI
{
    public class BillsData
    {

        public List<BillsDto> Bills { get; set; }

        //public static BillsData InstanciaActual { get; } = new BillsData();

        public BillsData()
        {
            Bills = new List<BillsDto>()
            {
                new BillsDto()
                {
                     Id = 1,
                     Nombre = "El Padrino",
                     CUIT  = 12354786,                  
                     Descripcion = "Drama Mafioso sobre una familia italiana",

                },
                new BillsDto()
                {
                    Id = 2,
                    Nombre = "Matrix",
                    Descripcion = "Ficcion En un mundo distopico controlado por maquinas",
                },
                new BillsDto()
                {
                    Id= 3,
                    Nombre = "Megamente",
                    Descripcion = "amogus",
                }
            };
        }
    }
}