using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mugi.Core.Migrations
{
    public partial class UpdateTableOrder_ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Orders",
                newName: "ConfirmDate");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<DateTime>(
                name: "CompleteDate",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompleteId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConfirmId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeliverId",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CompleteId",
                table: "Orders",
                column: "CompleteId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ConfirmId",
                table: "Orders",
                column: "ConfirmId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliverId",
                table: "Orders",
                column: "DeliverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Staffs_CompleteId",
                table: "Orders",
                column: "CompleteId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Staffs_ConfirmId",
                table: "Orders",
                column: "ConfirmId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Staffs_DeliverId",
                table: "Orders",
                column: "DeliverId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Staffs_CompleteId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Staffs_ConfirmId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Staffs_DeliverId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CompleteId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ConfirmId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliverId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CompleteDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CompleteId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ConfirmId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliverId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ConfirmDate",
                table: "Orders",
                newName: "ModifiedDate");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
