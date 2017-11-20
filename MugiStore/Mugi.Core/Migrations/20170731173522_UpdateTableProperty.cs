using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Mugi.Core.Migrations
{
    public partial class UpdateTableProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Staffs_StaffId",
                table: "Advertisements");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Accounts_AccountId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceipts_Staffs_StaffId",
                table: "GoodsReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceipts_Suppliers_SupplierId",
                table: "GoodsReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageProducts_Products_ProductId",
                table: "ImageProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_PriceDetails_Products_ProductId",
                table: "PriceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_Products_ProductId",
                table: "Promotions");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Accounts_AccountId",
                table: "Staffs");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                table: "SubCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_SubProducts_Products_ProductId",
                table: "SubProducts");

            migrationBuilder.DropTable(
                name: "PropertiesDetailsSubProducts");

            migrationBuilder.DropTable(
                name: "PropertiesProducts");

            migrationBuilder.DropTable(
                name: "PropertiesDetails");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Promotions_ProductId",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Promotions");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "SubProducts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "SubCategories",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "Staffs",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "PriceDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ImageProducts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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
                name: "AccountId",
                table: "Customers",
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
                name: "Property",
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
                    PropertiesName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyDetails",
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
                    PropertyId = table.Column<int>(nullable: false),
                    PropertyValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyDetails_Property_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Property",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyProducts",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    PropertiesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyProducts", x => new { x.ProductId, x.PropertiesId });
                    table.ForeignKey(
                        name: "FK_PropertyProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyProducts_Property_PropertiesId",
                        column: x => x.PropertiesId,
                        principalTable: "Property",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyDetailsSubProducts",
                columns: table => new
                {
                    PropertyDetailsId = table.Column<int>(nullable: false),
                    SubProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyDetailsSubProducts", x => new { x.PropertyDetailsId, x.SubProductId });
                    table.ForeignKey(
                        name: "FK_PropertyDetailsSubProducts_PropertyDetails_PropertyDetailsId",
                        column: x => x.PropertyDetailsId,
                        principalTable: "PropertyDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyDetailsSubProducts_SubProducts_SubProductId",
                        column: x => x.SubProductId,
                        principalTable: "SubProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertyDetails_PropertyId",
                table: "PropertyDetails",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyDetailsSubProducts_SubProductId",
                table: "PropertyDetailsSubProducts",
                column: "SubProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyProducts_PropertiesId",
                table: "PropertyProducts",
                column: "PropertiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_Staffs_StaffId",
                table: "Advertisements",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Accounts_AccountId",
                table: "Customers",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceipts_Staffs_StaffId",
                table: "GoodsReceipts",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceipts_Suppliers_SupplierId",
                table: "GoodsReceipts",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageProducts_Products_ProductId",
                table: "ImageProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PriceDetails_Products_ProductId",
                table: "PriceDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Accounts_AccountId",
                table: "Staffs",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                table: "SubCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubProducts_Products_ProductId",
                table: "SubProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Staffs_StaffId",
                table: "Advertisements");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Accounts_AccountId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceipts_Staffs_StaffId",
                table: "GoodsReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceipts_Suppliers_SupplierId",
                table: "GoodsReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageProducts_Products_ProductId",
                table: "ImageProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_PriceDetails_Products_ProductId",
                table: "PriceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Accounts_AccountId",
                table: "Staffs");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                table: "SubCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_SubProducts_Products_ProductId",
                table: "SubProducts");

            migrationBuilder.DropTable(
                name: "PropertyDetailsSubProducts");

            migrationBuilder.DropTable(
                name: "PropertyProducts");

            migrationBuilder.DropTable(
                name: "PropertyDetails");

            migrationBuilder.DropTable(
                name: "Property");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "SubProducts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "SubCategories",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "Staffs",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Promotions",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "PriceDetails",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ImageProducts",
                nullable: true,
                oldClrType: typeof(int));

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
                name: "AccountId",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "Advertisements",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "Properties",
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
                    PropertiesName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertiesDetails",
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
                    PropertiesId = table.Column<int>(nullable: true),
                    PropertiesValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertiesDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertiesDetails_Properties_PropertiesId",
                        column: x => x.PropertiesId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PropertiesProducts",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    PropertiesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertiesProducts", x => new { x.ProductId, x.PropertiesId });
                    table.ForeignKey(
                        name: "FK_PropertiesProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertiesProducts_Properties_PropertiesId",
                        column: x => x.PropertiesId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertiesDetailsSubProducts",
                columns: table => new
                {
                    PropertiesDetailsId = table.Column<int>(nullable: false),
                    SubProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertiesDetailsSubProducts", x => new { x.PropertiesDetailsId, x.SubProductId });
                    table.ForeignKey(
                        name: "FK_PropertiesDetailsSubProducts_PropertiesDetails_PropertiesDetailsId",
                        column: x => x.PropertiesDetailsId,
                        principalTable: "PropertiesDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertiesDetailsSubProducts_SubProducts_SubProductId",
                        column: x => x.SubProductId,
                        principalTable: "SubProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_ProductId",
                table: "Promotions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertiesDetails_PropertiesId",
                table: "PropertiesDetails",
                column: "PropertiesId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertiesDetailsSubProducts_SubProductId",
                table: "PropertiesDetailsSubProducts",
                column: "SubProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertiesProducts_PropertiesId",
                table: "PropertiesProducts",
                column: "PropertiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_Staffs_StaffId",
                table: "Advertisements",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Accounts_AccountId",
                table: "Customers",
                column: "AccountId",
                principalTable: "Accounts",
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
                name: "FK_ImageProducts_Products_ProductId",
                table: "ImageProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PriceDetails_Products_ProductId",
                table: "PriceDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_Products_ProductId",
                table: "Promotions",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Accounts_AccountId",
                table: "Staffs",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                table: "SubCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubProducts_Products_ProductId",
                table: "SubProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
