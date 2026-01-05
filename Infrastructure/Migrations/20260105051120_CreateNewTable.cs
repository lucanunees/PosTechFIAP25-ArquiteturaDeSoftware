using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateNewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DevelopedById",
                table: "Games",
                type: "VARCHAR(1000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "DevelopedBy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevelopedBy", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_DevelopedById",
                table: "Games",
                column: "DevelopedById");

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

            migrationBuilder.DropTable(
                name: "DevelopedBy");

            migrationBuilder.DropIndex(
                name: "IX_Games_DevelopedById",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "DevelopedById",
                table: "Games");
        }
    }
}
