using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateTablePromotion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Promotion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(1000)", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "DECIMAL(5,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    EndDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<int>(type: "INT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotion", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Promotion");
        }
    }
}
