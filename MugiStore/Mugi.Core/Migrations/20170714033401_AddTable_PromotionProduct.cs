using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mugi.Core.Migrations
{
    public partial class AddTable_PromotionProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PromotionNumber",
                table: "Promotions");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Promotions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PromotionProducts",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    PromotionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionProducts", x => new { x.ProductId, x.PromotionId });
                    table.ForeignKey(
                        name: "FK_PromotionProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PromotionProducts_Promotions_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_ProductId",
                table: "Promotions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionProducts_PromotionId",
                table: "PromotionProducts",
                column: "PromotionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_Products_ProductId",
                table: "Promotions",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_Products_ProductId",
                table: "Promotions");

            migrationBuilder.DropTable(
                name: "PromotionProducts");

            migrationBuilder.DropIndex(
                name: "IX_Promotions_ProductId",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "PromotionNumber",
                table: "Promotions",
                nullable: false,
                defaultValue: 0);
        }
    }
}
