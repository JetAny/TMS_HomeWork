using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGarageDB.Migrations
{
    public partial class Init_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "send_transport");

            migrationBuilder.AddColumn<bool>(
                name: "OnRoad",
                table: "transport",
                type: "tinyint(1)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OnRoad",
                table: "transport");

            migrationBuilder.CreateTable(
                name: "send_transport",
                columns: table => new
                {
                    IdSt = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    garage_Id = table.Column<int>(type: "int", nullable: true),
                    type_Id = table.Column<int>(type: "int", nullable: true),
                    brand = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fuelQuntity = table.Column<int>(type: "int", nullable: true),
                    fuelType = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    maxSpeed = table.Column<int>(type: "int", nullable: false),
                    namber = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.IdSt);
                    table.ForeignKey(
                        name: "send_transport_SG",
                        column: x => x.garage_Id,
                        principalTable: "Garages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "send_transport_ST",
                        column: x => x.type_Id,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "send_transport_SG",
                table: "send_transport",
                column: "garage_Id");

            migrationBuilder.CreateIndex(
                name: "send_transport_ST",
                table: "send_transport",
                column: "type_Id");
        }
    }
}
