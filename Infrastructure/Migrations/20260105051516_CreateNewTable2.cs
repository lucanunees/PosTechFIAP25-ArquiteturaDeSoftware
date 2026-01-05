using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateNewTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_DevelopedBy_DevelopedById",
                table: "Games");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_DevelopedBy_TempId",
                table: "DevelopedBy");

            migrationBuilder.DropColumn(
                name: "TempId",
                table: "DevelopedBy");

            migrationBuilder.AlterColumn<int>(
                name: "DevelopedById",
                table: "Games",
                type: "INT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(1000)");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_DevelopedBy_DevelopedById",
                table: "Games",
                column: "DevelopedById",
                principalTable: "DevelopedBy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_DevelopedBy_DevelopedById",
                table: "Games");

            migrationBuilder.AlterColumn<string>(
                name: "DevelopedById",
                table: "Games",
                type: "VARCHAR(1000)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AddColumn<string>(
                name: "TempId",
                table: "DevelopedBy",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_DevelopedBy_TempId",
                table: "DevelopedBy",
                column: "TempId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_DevelopedBy_DevelopedById",
                table: "Games",
                column: "DevelopedById",
                principalTable: "DevelopedBy",
                principalColumn: "TempId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
