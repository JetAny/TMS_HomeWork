using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGarageDB.Migrations
{
    public partial class Init_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Type",
                newName: "Types");

            migrationBuilder.RenameTable(
                name: "Garage",
                newName: "Garages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Types",
                newName: "Type");

            migrationBuilder.RenameTable(
                name: "Garages",
                newName: "Garage");
        }
    }
}
