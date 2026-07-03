using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreshMartPortal.Migrations
{
    /// <inheritdoc />
    public partial class AddBarcode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                table: "StockItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Barcode",
                table: "StockItems");
        }
    }
}
