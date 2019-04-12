using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StopWatcher.Migrations
{
    public partial class ColumnsRetooling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TradingPair",
                table: "Securities");

            migrationBuilder.RenameColumn(
                name: "Units",
                table: "OpenOrders",
                newName: "QuantityRemaining");

            migrationBuilder.AlterColumn<decimal>(
                name: "StopPriceUSD",
                table: "StopOrders",
                type: "decimal(20, 8)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(20, 8)");

            migrationBuilder.AddColumn<string>(
                name: "TradingPair",
                table: "StopOrders",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PxUSD",
                table: "Securities",
                type: "decimal(20, 8)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(20, 8)");

            migrationBuilder.AddColumn<int>(
                name: "OrderType",
                table: "OpenOrders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderUuid",
                table: "OpenOrders",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "OpenOrders",
                type: "decimal(20, 8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "TradingPair",
                table: "OpenOrders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TradingPair",
                table: "StopOrders");

            migrationBuilder.DropColumn(
                name: "OrderType",
                table: "OpenOrders");

            migrationBuilder.DropColumn(
                name: "OrderUuid",
                table: "OpenOrders");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OpenOrders");

            migrationBuilder.DropColumn(
                name: "TradingPair",
                table: "OpenOrders");

            migrationBuilder.RenameColumn(
                name: "QuantityRemaining",
                table: "OpenOrders",
                newName: "Units");

            migrationBuilder.AlterColumn<decimal>(
                name: "StopPriceUSD",
                table: "StopOrders",
                type: "decimal(20, 8)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20, 8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PxUSD",
                table: "Securities",
                type: "decimal(20, 8)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20, 8)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TradingPair",
                table: "Securities",
                nullable: true);
        }
    }
}
