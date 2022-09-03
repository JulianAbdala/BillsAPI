using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RatingAPI.Migrations
{
    public partial class dataInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "Id", "CUIT", "Descripcion", "Nombre", "Precio" },
                values: new object[] { 1, 12365986L, "Siete KG de mortadela", "Coto", 6000L });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "Id", "CUIT", "Descripcion", "Nombre", "Precio" },
                values: new object[] { 2, 12345874L, "De Parana a Rosario", "Taxis", 3000L });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "Id", "CUIT", "Descripcion", "Nombre", "Precio" },
                values: new object[] { 3, 86865474L, "Devengamiento por prestacion de servicios", "Servicio Internet", 5000L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
