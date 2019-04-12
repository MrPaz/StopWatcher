using Microsoft.EntityFrameworkCore.Migrations;

namespace StopWatcher.Migrations
{
    public partial class MarketSummary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarketDatas_GetMarketSummaryResult_MarketSummarriesID",
                table: "MarketDatas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GetMarketSummaryResult",
                table: "GetMarketSummaryResult");

            migrationBuilder.RenameTable(
                name: "GetMarketSummaryResult",
                newName: "GetMarketSummaryResults");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GetMarketSummaryResults",
                table: "GetMarketSummaryResults",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_MarketDatas_GetMarketSummaryResults_MarketSummarriesID",
                table: "MarketDatas",
                column: "MarketSummarriesID",
                principalTable: "GetMarketSummaryResults",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarketDatas_GetMarketSummaryResults_MarketSummarriesID",
                table: "MarketDatas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GetMarketSummaryResults",
                table: "GetMarketSummaryResults");

            migrationBuilder.RenameTable(
                name: "GetMarketSummaryResults",
                newName: "GetMarketSummaryResult");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GetMarketSummaryResult",
                table: "GetMarketSummaryResult",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_MarketDatas_GetMarketSummaryResult_MarketSummarriesID",
                table: "MarketDatas",
                column: "MarketSummarriesID",
                principalTable: "GetMarketSummaryResult",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
