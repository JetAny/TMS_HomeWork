using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGarageDB.Migrations
{
    public partial class Init_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "transport_FK",
                table: "transport");

            migrationBuilder.DropForeignKey(
                name: "transport_TP",
                table: "transport");

            migrationBuilder.RenameColumn(
                name: "type_Id",
                table: "transport",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "garage_Id",
                table: "transport",
                newName: "GarageId");

            migrationBuilder.RenameIndex(
                name: "transport_TP",
                table: "transport",
                newName: "IX_transport_TypeId");

            migrationBuilder.RenameIndex(
                name: "transport_FK",
                table: "transport",
                newName: "IX_transport_GarageId");

            migrationBuilder.UpdateData(
                table: "type",
                keyColumn: "type",
                keyValue: null,
                column: "type",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "type",
                table: "type",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_transport_garage_GarageId",
                table: "transport",
                column: "GarageId",
                principalTable: "garage",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_transport_type_TypeId",
                table: "transport",
                column: "TypeId",
                principalTable: "type",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transport_garage_GarageId",
                table: "transport");

            migrationBuilder.DropForeignKey(
                name: "FK_transport_type_TypeId",
                table: "transport");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "transport",
                newName: "type_Id");

            migrationBuilder.RenameColumn(
                name: "GarageId",
                table: "transport",
                newName: "garage_Id");

            migrationBuilder.RenameIndex(
                name: "IX_transport_TypeId",
                table: "transport",
                newName: "transport_TP");

            migrationBuilder.RenameIndex(
                name: "IX_transport_GarageId",
                table: "transport",
                newName: "transport_FK");

            migrationBuilder.AlterColumn<string>(
                name: "type",
                table: "type",
                type: "varchar(10)",
                maxLength: 10,
                nullable: true,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AddForeignKey(
                name: "transport_FK",
                table: "transport",
                column: "garage_Id",
                principalTable: "garage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "transport_TP",
                table: "transport",
                column: "type_Id",
                principalTable: "type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
