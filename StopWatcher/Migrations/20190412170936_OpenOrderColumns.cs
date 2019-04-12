using Microsoft.EntityFrameworkCore.Migrations;

namespace StopWatcher.Migrations
{
    public partial class OpenOrderColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BidPxBTC",
                table: "OpenOrders");

            migrationBuilder.DropColumn(
                name: "BidPxUSD",
                table: "OpenOrders");

            migrationBuilder.AddColumn<decimal>(
                name: "OrderPx",
                table: "OpenOrders",
                type: "decimal(20, 8)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderPx",
                table: "OpenOrders");

            migrationBuilder.AddColumn<decimal>(
                name: "BidPxBTC",
                table: "OpenOrders",
                type: "decimal(20, 8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BidPxUSD",
                table: "OpenOrders",
                type: "decimal(20, 8)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
