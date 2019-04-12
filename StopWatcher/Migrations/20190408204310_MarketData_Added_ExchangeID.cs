using Microsoft.EntityFrameworkCore.Migrations;

namespace StopWatcher.Migrations
{
    public partial class MarketData_Added_ExchangeID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExchangeID",
                table: "MarketDatas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExchangeID1",
                table: "MarketDatas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MarketDatas_ExchangeID1",
                table: "MarketDatas",
                column: "ExchangeID1");

            migrationBuilder.AddForeignKey(
                name: "FK_MarketDatas_Exchanges_ExchangeID1",
                table: "MarketDatas",
                column: "ExchangeID1",
                principalTable: "Exchanges",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarketDatas_Exchanges_ExchangeID1",
                table: "MarketDatas");

            migrationBuilder.DropIndex(
                name: "IX_MarketDatas_ExchangeID1",
                table: "MarketDatas");

            migrationBuilder.DropColumn(
                name: "ExchangeID",
                table: "MarketDatas");

            migrationBuilder.DropColumn(
                name: "ExchangeID1",
                table: "MarketDatas");
        }
    }
}
