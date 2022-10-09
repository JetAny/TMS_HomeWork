using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGarageDB.Migrations
{
    public partial class Init_7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transport_Ovners_OvnerDBId",
                table: "transport");

            migrationBuilder.DropIndex(
                name: "IX_transport_OvnerDBId",
                table: "transport");

            migrationBuilder.DropColumn(
                name: "OvnerDBId",
                table: "transport");

            migrationBuilder.AddColumn<int>(
                name: "OvnerId",
                table: "transport",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_transport_OvnerId",
                table: "transport",
                column: "OvnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_transport_Ovners_OvnerId",
                table: "transport",
                column: "OvnerId",
                principalTable: "Ovners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transport_Ovners_OvnerId",
                table: "transport");

            migrationBuilder.DropIndex(
                name: "IX_transport_OvnerId",
                table: "transport");

            migrationBuilder.DropColumn(
                name: "OvnerId",
                table: "transport");

            migrationBuilder.AddColumn<int>(
                name: "OvnerDBId",
                table: "transport",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_transport_OvnerDBId",
                table: "transport",
                column: "OvnerDBId");

            migrationBuilder.AddForeignKey(
                name: "FK_transport_Ovners_OvnerDBId",
                table: "transport",
                column: "OvnerDBId",
                principalTable: "Ovners",
                principalColumn: "Id");
        }
    }
}
