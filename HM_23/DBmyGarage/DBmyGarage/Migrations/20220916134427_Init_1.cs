using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGarageDB.Migrations
{
    public partial class Init_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Garage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Sity = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    type = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "send_transport",
                columns: table => new
                {
                    IdSt = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id = table.Column<int>(type: "int", nullable: false),
                    fuelType = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fuelQuntity = table.Column<int>(type: "int", nullable: true),
                    brand = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    maxSpeed = table.Column<int>(type: "int", nullable: false),
                    namber = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    type_Id = table.Column<int>(type: "int", nullable: true),
                    garage_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.IdSt);
                    table.ForeignKey(
                        name: "send_transport_SG",
                        column: x => x.garage_Id,
                        principalTable: "Garage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "send_transport_ST",
                        column: x => x.type_Id,
                        principalTable: "Type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "transport",
                columns: table => new
                {
                    IdTr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    fuelType = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fuelQuntity = table.Column<int>(type: "int", nullable: true),
                    brand = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    maxSpeed = table.Column<int>(type: "int", nullable: false),
                    namber = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    type_Id = table.Column<int>(type: "int", nullable: true),
                    garage_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.IdTr);
                    table.ForeignKey(
                        name: "transport_FK",
                        column: x => x.garage_Id,
                        principalTable: "Garage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "transport_TP",
                        column: x => x.type_Id,
                        principalTable: "Type",
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

            migrationBuilder.CreateIndex(
                name: "transport_FK",
                table: "transport",
                column: "garage_Id");

            migrationBuilder.CreateIndex(
                name: "transport_TP",
                table: "transport",
                column: "type_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "send_transport");

            migrationBuilder.DropTable(
                name: "transport");

            migrationBuilder.DropTable(
                name: "Garage");

            migrationBuilder.DropTable(
                name: "Type");
        }
    }
}
