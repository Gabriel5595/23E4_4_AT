using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeStore.Migrations
{
    /// <inheritdoc />
    public partial class AddTableProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_BRAND",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_BRAND", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "TB_PRODUCT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<double>(type: "float", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRODUCT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_PRODUCT_TB_BRAND_BrandId",
                        column: x => x.BrandId,
                        principalTable: "TB_BRAND",
                        principalColumn: "BrandId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PRODUCT_BrandId",
                table: "TB_PRODUCT",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PRODUCT");

            migrationBuilder.DropTable(
                name: "TB_BRAND");
        }
    }
}
