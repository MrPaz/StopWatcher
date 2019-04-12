using Microsoft.EntityFrameworkCore.Migrations;

namespace StopWatcher.Migrations
{
    public partial class BittrexPackage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Volume",
                table: "GetMarketSummaryResults",
                type: "decimal(20, 8)",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<decimal>(
                name: "PrevDay",
                table: "GetMarketSummaryResults",
                type: "decimal(20, 8)",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<decimal>(
                name: "Low",
                table: "GetMarketSummaryResults",
                type: "decimal(20, 8)",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<decimal>(
                name: "Last",
                table: "GetMarketSummaryResults",
                type: "decimal(20, 8)",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<decimal>(
                name: "High",
                table: "GetMarketSummaryResults",
                type: "decimal(20, 8)",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<decimal>(
                name: "Bid",
                table: "GetMarketSummaryResults",
                type: "decimal(20, 8)",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<decimal>(
                name: "BaseVolume",
                table: "GetMarketSummaryResults",
                type: "decimal(20, 8)",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<decimal>(
                name: "Ask",
                table: "GetMarketSummaryResults",
                type: "decimal(20, 8)",
                nullable: false,
                oldClrType: typeof(float));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Volume",
                table: "GetMarketSummaryResults",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20, 8)");

            migrationBuilder.AlterColumn<float>(
                name: "PrevDay",
                table: "GetMarketSummaryResults",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20, 8)");

            migrationBuilder.AlterColumn<float>(
                name: "Low",
                table: "GetMarketSummaryResults",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20, 8)");

            migrationBuilder.AlterColumn<float>(
                name: "Last",
                table: "GetMarketSummaryResults",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20, 8)");

            migrationBuilder.AlterColumn<float>(
                name: "High",
                table: "GetMarketSummaryResults",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20, 8)");

            migrationBuilder.AlterColumn<float>(
                name: "Bid",
                table: "GetMarketSummaryResults",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20, 8)");

            migrationBuilder.AlterColumn<float>(
                name: "BaseVolume",
                table: "GetMarketSummaryResults",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20, 8)");

            migrationBuilder.AlterColumn<float>(
                name: "Ask",
                table: "GetMarketSummaryResults",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20, 8)");
        }
    }
}
