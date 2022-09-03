using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RatingAPI.Migrations
{
    public partial class segundamigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    SurName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    UserType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Name", "Password", "SurName", "UserName", "UserType" },
                values: new object[] { 1, "julian", "juli123", "abdala", "turco", 1 });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Name", "Password", "SurName", "UserName", "UserType" },
                values: new object[] { 2, "lola", "catchow", "gato", "pipi", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

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
    }
}
