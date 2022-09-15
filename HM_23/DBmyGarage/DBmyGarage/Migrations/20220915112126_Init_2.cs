using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBmyGarage.Migrations
{
    public partial class Init_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_garages",
                table: "garages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_type",
                table: "type");

            migrationBuilder.RenameTable(
                name: "garages",
                newName: "Garages");

            migrationBuilder.RenameTable(
                name: "type",
                newName: "Types");

            migrationBuilder.AddPrimaryKey(
                name: "PRIMARY",
                table: "Garages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PRIMARY",
                table: "Types",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PRIMARY",
                table: "Garages");

            migrationBuilder.DropPrimaryKey(
                name: "PRIMARY",
                table: "Types");

            migrationBuilder.RenameTable(
                name: "Garages",
                newName: "garages");

            migrationBuilder.RenameTable(
                name: "Types",
                newName: "type");

            migrationBuilder.AddPrimaryKey(
                name: "PK_garages",
                table: "garages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_type",
                table: "type",
                column: "Id");
        }
    }
}
