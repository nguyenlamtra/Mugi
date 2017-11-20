using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Mugi.Core.Migrations
{
    public partial class UpdateTableOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "TypePayments");

            migrationBuilder.DropColumn(
                name: "BillId",
                table: "ReturnProducts");

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "ReturnProducts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "ReturnProducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentType",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Total",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "GoodsReceipts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "GoodsReceipts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "Advertisements",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_ReturnProducts_OrderId",
                table: "ReturnProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnProducts_StaffId",
                table: "ReturnProducts",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceipts_StaffId",
                table: "GoodsReceipts",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceipts_SupplierId",
                table: "GoodsReceipts",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_StaffId",
                table: "Advertisements",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_Staffs_StaffId",
                table: "Advertisements",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceipts_Staffs_StaffId",
                table: "GoodsReceipts",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceipts_Suppliers_SupplierId",
                table: "GoodsReceipts",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnProducts_Orders_OrderId",
                table: "ReturnProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnProducts_Staffs_StaffId",
                table: "ReturnProducts",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Staffs_StaffId",
                table: "Advertisements");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceipts_Staffs_StaffId",
                table: "GoodsReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceipts_Suppliers_SupplierId",
                table: "GoodsReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnProducts_Orders_OrderId",
                table: "ReturnProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnProducts_Staffs_StaffId",
                table: "ReturnProducts");

            migrationBuilder.DropIndex(
                name: "IX_ReturnProducts_OrderId",
                table: "ReturnProducts");

            migrationBuilder.DropIndex(
                name: "IX_ReturnProducts_StaffId",
                table: "ReturnProducts");

            migrationBuilder.DropIndex(
                name: "IX_GoodsReceipts_StaffId",
                table: "GoodsReceipts");

            migrationBuilder.DropIndex(
                name: "IX_GoodsReceipts_SupplierId",
                table: "GoodsReceipts");

            migrationBuilder.DropIndex(
                name: "IX_Advertisements_StaffId",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "ReturnProducts");

            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "ReturnProducts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BillId",
                table: "ReturnProducts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "GoodsReceipts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "GoodsReceipts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "Advertisements",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DeletedBy = table.Column<int>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    OrderId = table.Column<int>(nullable: false),
                    StaffId = table.Column<int>(nullable: false),
                    Total = table.Column<int>(nullable: false),
                    TypePaymentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypePayments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DeletedBy = table.Column<int>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    PaymentTypeName = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypePayments", x => x.Id);
                });
        }
    }
}
