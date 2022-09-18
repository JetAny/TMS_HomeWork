using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGarageDB.Migrations
{
    public partial class Init_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Types",
                newName: "type");

            migrationBuilder.RenameTable(
                name: "Garages",
                newName: "garage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "type",
                newName: "Types");

            migrationBuilder.RenameTable(
                name: "garage",
                newName: "Garages");
        }
    }
}
