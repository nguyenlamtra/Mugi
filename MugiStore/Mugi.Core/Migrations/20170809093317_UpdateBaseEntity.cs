using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mugi.Core.Migrations
{
    public partial class UpdateBaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SubProducts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SubProducts");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "SubProducts");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "SubProducts");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "SubProducts");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "SubProducts");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ReturnProducts");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "ReturnProducts");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "ReturnProducts");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ReturnProducts");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "ReturnProducts");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PropertyDetails");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PropertyDetails");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "PropertyDetails");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "PropertyDetails");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "PropertyDetails");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "PropertyDetails");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Propertys");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Propertys");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Propertys");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Propertys");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Propertys");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Propertys");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PriceDetails");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PriceDetails");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "PriceDetails");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "PriceDetails");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "PriceDetails");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "PriceDetails");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ImageProducts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ImageProducts");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "ImageProducts");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "ImageProducts");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ImageProducts");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "ImageProducts");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GoodsReceipts");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "GoodsReceipts");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "GoodsReceipts");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GoodsReceipts");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "GoodsReceipts");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "Promotions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_StaffId",
                table: "Promotions",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_Staffs_StaffId",
                table: "Promotions",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_Staffs_StaffId",
                table: "Promotions");

            migrationBuilder.DropIndex(
                name: "IX_Promotions_StaffId",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Promotions");

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Suppliers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Suppliers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Suppliers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Suppliers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Suppliers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Suppliers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "SubProducts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "SubProducts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "SubProducts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "SubProducts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "SubProducts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "SubProducts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "SubCategories",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "SubCategories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "SubCategories",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "SubCategories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "SubCategories",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "SubCategories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Staffs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Staffs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Staffs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Staffs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Staffs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Staffs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Roles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "ReturnProducts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "ReturnProducts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "ReturnProducts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "ReturnProducts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "ReturnProducts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "PropertyDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PropertyDetails",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "PropertyDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "PropertyDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "PropertyDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "PropertyDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Propertys",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Propertys",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Propertys",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Propertys",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Propertys",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Propertys",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Promotions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Promotions",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Promotions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Promotions",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Promotions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "PriceDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PriceDetails",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "PriceDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "PriceDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "PriceDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "PriceDetails",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "ImageProducts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ImageProducts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "ImageProducts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "ImageProducts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "ImageProducts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "ImageProducts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "GoodsReceipts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "GoodsReceipts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "GoodsReceipts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "GoodsReceipts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "GoodsReceipts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Customers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Advertisements",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Advertisements",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Advertisements",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Advertisements",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Advertisements",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Accounts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Accounts",
                nullable: true);
        }
    }
}
