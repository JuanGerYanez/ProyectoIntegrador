using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_luna_planeta_planeta_lunacodigo_planeta",
                table: "luna");

            migrationBuilder.AlterColumn<string>(
                name: "planeta_lunacodigo_planeta",
                table: "luna",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_luna_planeta_planeta_lunacodigo_planeta",
                table: "luna",
                column: "planeta_lunacodigo_planeta",
                principalTable: "planeta",
                principalColumn: "codigo_planeta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_luna_planeta_planeta_lunacodigo_planeta",
                table: "luna");

            migrationBuilder.AlterColumn<string>(
                name: "planeta_lunacodigo_planeta",
                table: "luna",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_luna_planeta_planeta_lunacodigo_planeta",
                table: "luna",
                column: "planeta_lunacodigo_planeta",
                principalTable: "planeta",
                principalColumn: "codigo_planeta",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
