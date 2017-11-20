using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mugi.Core.Migrations
{
    public partial class AddTableOrderSubProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PropertiesDetailsSubProducts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PropertiesDetailsSubProducts");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "PropertiesDetailsSubProducts");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "PropertiesDetailsSubProducts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PropertiesDetailsSubProducts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PropertiesDetailsSubProducts");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "PropertiesDetailsSubProducts");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "PropertiesDetailsSubProducts");

            migrationBuilder.CreateTable(
                name: "OrderSubProducts",
                columns: table => new
                {
                    SubProductId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderSubProducts", x => new { x.SubProductId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_OrderSubProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderSubProducts_SubProducts_SubProductId",
                        column: x => x.SubProductId,
                        principalTable: "SubProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderSubProducts_OrderId",
                table: "OrderSubProducts",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderSubProducts");

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "PropertiesDetailsSubProducts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PropertiesDetailsSubProducts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "PropertiesDetailsSubProducts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "PropertiesDetailsSubProducts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PropertiesDetailsSubProducts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PropertiesDetailsSubProducts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "PropertiesDetailsSubProducts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "PropertiesDetailsSubProducts",
                nullable: true);
        }
    }
}
