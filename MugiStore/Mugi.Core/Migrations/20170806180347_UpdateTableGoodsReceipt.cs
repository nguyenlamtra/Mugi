using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mugi.Core.Migrations
{
    public partial class UpdateTableGoodsReceipt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "GoodsReceiptSubProducts");

            migrationBuilder.CreateTable(
                name: "GoodsReceiptProducts",
                columns: table => new
                {
                    GoodsReceiptId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    PriceInsert = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsReceiptProducts", x => new { x.GoodsReceiptId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_GoodsReceiptProducts_GoodsReceipts_GoodsReceiptId",
                        column: x => x.GoodsReceiptId,
                        principalTable: "GoodsReceipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodsReceiptProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiptProducts_ProductId",
                table: "GoodsReceiptProducts",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoodsReceiptProducts");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "GoodsReceiptSubProducts",
                nullable: false,
                defaultValue: 0);
        }
    }
}
