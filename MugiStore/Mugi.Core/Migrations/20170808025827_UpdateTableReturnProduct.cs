using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mugi.Core.Migrations
{
    public partial class UpdateTableReturnProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReturnProducts_Orders_OrderId",
                table: "ReturnProducts");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "ReturnProducts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnProducts_Orders_OrderId",
                table: "ReturnProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReturnProducts_Orders_OrderId",
                table: "ReturnProducts");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "ReturnProducts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnProducts_Orders_OrderId",
                table: "ReturnProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
