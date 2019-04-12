using Microsoft.EntityFrameworkCore.Migrations;

namespace StopWatcher.Migrations
{
    public partial class Decimals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Units",
                table: "StopOrders",
                type: "decimal(20, 8)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "StopPriceUSD",
                table: "StopOrders",
                type: "decimal(20, 8)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "StopPriceBTC",
                table: "StopOrders",
                type: "decimal(20, 8)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "StopPercent",
                table: "StopOrders",
                type: "decimal(20, 8)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "PxUSD",
                table: "Securities",
                type: "decimal(20, 8)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "PxBTC",
                table: "Securities",
                type: "decimal(20, 8)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "WtdAvgBuyPriceUSD",
                table: "Positions",
                type: "decimal(20, 8)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "WtdAvgBuyPriceBTC",
                table: "Positions",
                type: "decimal(20, 8)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "Units",
                table: "Positions",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "Units",
                table: "OpenOrders",
                type: "decimal(20, 8)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "BidPxUSD",
                table: "OpenOrders",
                type: "decimal(20, 8)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "BidPxBTC",
                table: "OpenOrders",
                type: "decimal(20, 8)",
                nullable: false,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Units",
                table: "StopOrders",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20, 8)");

            migrationBuilder.AlterColumn<double>(
                name: "StopPriceUSD",
                table: "StopOrders",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20, 8)");

            migrationBuilder.AlterColumn<double>(
                name: "StopPriceBTC",
                table: "StopOrders",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20, 8)");

            migrationBuilder.AlterColumn<double>(
                name: "StopPercent",
                table: "StopOrders",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20, 8)");

            migrationBuilder.AlterColumn<double>(
                name: "PxUSD",
                table: "Securities",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20, 8)");

            migrationBuilder.AlterColumn<double>(
                name: "PxBTC",
                table: "Securities",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20, 8)");

            migrationBuilder.AlterColumn<double>(
                name: "WtdAvgBuyPriceUSD",
                table: "Positions",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20, 8)");

            migrationBuilder.AlterColumn<double>(
                name: "WtdAvgBuyPriceBTC",
                table: "Positions",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20, 8)");

            migrationBuilder.AlterColumn<double>(
                name: "Units",
                table: "Positions",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<double>(
                name: "Units",
                table: "OpenOrders",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20, 8)");

            migrationBuilder.AlterColumn<double>(
                name: "BidPxUSD",
                table: "OpenOrders",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20, 8)");

            migrationBuilder.AlterColumn<double>(
                name: "BidPxBTC",
                table: "OpenOrders",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20, 8)");
        }
    }
}
