using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Mugi.Core.Migrations
{
    public partial class UpdateTableShopOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Roles_RoleId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Staffs_StaffId",
                table: "Advertisements");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Accounts_AccountId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceiptProducts_GoodsReceipts_GoodsReceiptId",
                table: "GoodsReceiptProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceiptProducts_Products_ProductId",
                table: "GoodsReceiptProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceipts_Staffs_StaffId",
                table: "GoodsReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceiptSubProducts_GoodsReceipts_GoodsReceiptId",
                table: "GoodsReceiptSubProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceiptSubProducts_SubProducts_SubProductId",
                table: "GoodsReceiptSubProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageProducts_Products_ProductId",
                table: "ImageProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Orders_OrderId",
                table: "OrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Products_ProductId",
                table: "OrderProducts");

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

            migrationBuilder.DropForeignKey(
                name: "FK_OrderSubProducts_Orders_OrderId",
                table: "OrderSubProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderSubProducts_SubProducts_SubProductId",
                table: "OrderSubProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_PriceDetails_Products_ProductId",
                table: "PriceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_SubCategories_SubCategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Suppliers_SupplierId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_PromotionProducts_Products_ProductId",
                table: "PromotionProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_PromotionProducts_Promotions_PromotionId",
                table: "PromotionProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_Staffs_StaffId",
                table: "Promotions");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyDetails_Propertys_PropertyId",
                table: "PropertyDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyDetailsSubProducts_PropertyDetails_PropertyDetailsId",
                table: "PropertyDetailsSubProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyDetailsSubProducts_SubProducts_SubProductId",
                table: "PropertyDetailsSubProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyProducts_Products_ProductId",
                table: "PropertyProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyProducts_Propertys_PropertyId",
                table: "PropertyProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnProducts_Orders_OrderId",
                table: "ReturnProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnProducts_Staffs_StaffId",
                table: "ReturnProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnProductSubProducts_ReturnProducts_ReturnProductId",
                table: "ReturnProductSubProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnProductSubProducts_SubProducts_SubProductId",
                table: "ReturnProductSubProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Accounts_AccountId",
                table: "Staffs");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                table: "SubCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_SubProducts_Products_ProductId",
                table: "SubProducts");

            migrationBuilder.AddColumn<int>(
                name: "ShopOrderId",
                table: "GoodsReceipts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ShopOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopOrders_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShopOrderProducts",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ShopOrderId = table.Column<int>(type: "int", nullable: false),
                    PriceInput = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopOrderProducts", x => new { x.ProductId, x.ShopOrderId });
                    table.ForeignKey(
                        name: "FK_ShopOrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShopOrderProducts_ShopOrders_ShopOrderId",
                        column: x => x.ShopOrderId,
                        principalTable: "ShopOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShopOrderSubProducts",
                columns: table => new
                {
                    SubProductId = table.Column<int>(type: "int", nullable: false),
                    ShopOrderId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopOrderSubProducts", x => new { x.SubProductId, x.ShopOrderId });
                    table.ForeignKey(
                        name: "FK_ShopOrderSubProducts_ShopOrders_ShopOrderId",
                        column: x => x.ShopOrderId,
                        principalTable: "ShopOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShopOrderSubProducts_SubProducts_SubProductId",
                        column: x => x.SubProductId,
                        principalTable: "SubProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceipts_ShopOrderId",
                table: "GoodsReceipts",
                column: "ShopOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopOrderProducts_ShopOrderId",
                table: "ShopOrderProducts",
                column: "ShopOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopOrders_SupplierId",
                table: "ShopOrders",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopOrderSubProducts_ShopOrderId",
                table: "ShopOrderSubProducts",
                column: "ShopOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Roles_RoleId",
                table: "Accounts",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_GoodsReceiptProducts_GoodsReceipts_GoodsReceiptId",
                table: "GoodsReceiptProducts",
                column: "GoodsReceiptId",
                principalTable: "GoodsReceipts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceiptProducts_Products_ProductId",
                table: "GoodsReceiptProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceipts_ShopOrders_ShopOrderId",
                table: "GoodsReceipts",
                column: "ShopOrderId",
                principalTable: "ShopOrders",
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
                name: "FK_GoodsReceiptSubProducts_GoodsReceipts_GoodsReceiptId",
                table: "GoodsReceiptSubProducts",
                column: "GoodsReceiptId",
                principalTable: "GoodsReceipts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceiptSubProducts_SubProducts_SubProductId",
                table: "GoodsReceiptSubProducts",
                column: "SubProductId",
                principalTable: "SubProducts",
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
                name: "FK_OrderProducts_Orders_OrderId",
                table: "OrderProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Products_ProductId",
                table: "OrderProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSubProducts_Orders_OrderId",
                table: "OrderSubProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSubProducts_SubProducts_SubProductId",
                table: "OrderSubProducts",
                column: "SubProductId",
                principalTable: "SubProducts",
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
                name: "FK_Products_SubCategories_SubCategoryId",
                table: "Products",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Suppliers_SupplierId",
                table: "Products",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PromotionProducts_Products_ProductId",
                table: "PromotionProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PromotionProducts_Promotions_PromotionId",
                table: "PromotionProducts",
                column: "PromotionId",
                principalTable: "Promotions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_Staffs_StaffId",
                table: "Promotions",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyDetails_Propertys_PropertyId",
                table: "PropertyDetails",
                column: "PropertyId",
                principalTable: "Propertys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyDetailsSubProducts_PropertyDetails_PropertyDetailsId",
                table: "PropertyDetailsSubProducts",
                column: "PropertyDetailsId",
                principalTable: "PropertyDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyDetailsSubProducts_SubProducts_SubProductId",
                table: "PropertyDetailsSubProducts",
                column: "SubProductId",
                principalTable: "SubProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyProducts_Products_ProductId",
                table: "PropertyProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyProducts_Propertys_PropertyId",
                table: "PropertyProducts",
                column: "PropertyId",
                principalTable: "Propertys",
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

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnProductSubProducts_ReturnProducts_ReturnProductId",
                table: "ReturnProductSubProducts",
                column: "ReturnProductId",
                principalTable: "ReturnProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnProductSubProducts_SubProducts_SubProductId",
                table: "ReturnProductSubProducts",
                column: "SubProductId",
                principalTable: "SubProducts",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Roles_RoleId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Staffs_StaffId",
                table: "Advertisements");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Accounts_AccountId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceiptProducts_GoodsReceipts_GoodsReceiptId",
                table: "GoodsReceiptProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceiptProducts_Products_ProductId",
                table: "GoodsReceiptProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceipts_ShopOrders_ShopOrderId",
                table: "GoodsReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceipts_Staffs_StaffId",
                table: "GoodsReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceiptSubProducts_GoodsReceipts_GoodsReceiptId",
                table: "GoodsReceiptSubProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceiptSubProducts_SubProducts_SubProductId",
                table: "GoodsReceiptSubProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageProducts_Products_ProductId",
                table: "ImageProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Orders_OrderId",
                table: "OrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Products_ProductId",
                table: "OrderProducts");

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

            migrationBuilder.DropForeignKey(
                name: "FK_OrderSubProducts_Orders_OrderId",
                table: "OrderSubProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderSubProducts_SubProducts_SubProductId",
                table: "OrderSubProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_PriceDetails_Products_ProductId",
                table: "PriceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_SubCategories_SubCategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Suppliers_SupplierId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_PromotionProducts_Products_ProductId",
                table: "PromotionProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_PromotionProducts_Promotions_PromotionId",
                table: "PromotionProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_Staffs_StaffId",
                table: "Promotions");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyDetails_Propertys_PropertyId",
                table: "PropertyDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyDetailsSubProducts_PropertyDetails_PropertyDetailsId",
                table: "PropertyDetailsSubProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyDetailsSubProducts_SubProducts_SubProductId",
                table: "PropertyDetailsSubProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyProducts_Products_ProductId",
                table: "PropertyProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyProducts_Propertys_PropertyId",
                table: "PropertyProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnProducts_Orders_OrderId",
                table: "ReturnProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnProducts_Staffs_StaffId",
                table: "ReturnProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnProductSubProducts_ReturnProducts_ReturnProductId",
                table: "ReturnProductSubProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnProductSubProducts_SubProducts_SubProductId",
                table: "ReturnProductSubProducts");

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
                name: "ShopOrderProducts");

            migrationBuilder.DropTable(
                name: "ShopOrderSubProducts");

            migrationBuilder.DropTable(
                name: "ShopOrders");

            migrationBuilder.DropIndex(
                name: "IX_GoodsReceipts_ShopOrderId",
                table: "GoodsReceipts");

            migrationBuilder.DropColumn(
                name: "ShopOrderId",
                table: "GoodsReceipts");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Roles_RoleId",
                table: "Accounts",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_GoodsReceiptProducts_GoodsReceipts_GoodsReceiptId",
                table: "GoodsReceiptProducts",
                column: "GoodsReceiptId",
                principalTable: "GoodsReceipts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceiptProducts_Products_ProductId",
                table: "GoodsReceiptProducts",
                column: "ProductId",
                principalTable: "Products",
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
                name: "FK_GoodsReceiptSubProducts_GoodsReceipts_GoodsReceiptId",
                table: "GoodsReceiptSubProducts",
                column: "GoodsReceiptId",
                principalTable: "GoodsReceipts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceiptSubProducts_SubProducts_SubProductId",
                table: "GoodsReceiptSubProducts",
                column: "SubProductId",
                principalTable: "SubProducts",
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
                name: "FK_OrderProducts_Orders_OrderId",
                table: "OrderProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Products_ProductId",
                table: "OrderProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Staffs_DeliverId",
                table: "Orders",
                column: "DeliverId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSubProducts_Orders_OrderId",
                table: "OrderSubProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSubProducts_SubProducts_SubProductId",
                table: "OrderSubProducts",
                column: "SubProductId",
                principalTable: "SubProducts",
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
                name: "FK_Products_SubCategories_SubCategoryId",
                table: "Products",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Suppliers_SupplierId",
                table: "Products",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PromotionProducts_Products_ProductId",
                table: "PromotionProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PromotionProducts_Promotions_PromotionId",
                table: "PromotionProducts",
                column: "PromotionId",
                principalTable: "Promotions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_Staffs_StaffId",
                table: "Promotions",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyDetails_Propertys_PropertyId",
                table: "PropertyDetails",
                column: "PropertyId",
                principalTable: "Propertys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyDetailsSubProducts_PropertyDetails_PropertyDetailsId",
                table: "PropertyDetailsSubProducts",
                column: "PropertyDetailsId",
                principalTable: "PropertyDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyDetailsSubProducts_SubProducts_SubProductId",
                table: "PropertyDetailsSubProducts",
                column: "SubProductId",
                principalTable: "SubProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyProducts_Products_ProductId",
                table: "PropertyProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyProducts_Propertys_PropertyId",
                table: "PropertyProducts",
                column: "PropertyId",
                principalTable: "Propertys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnProducts_Orders_OrderId",
                table: "ReturnProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnProducts_Staffs_StaffId",
                table: "ReturnProducts",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnProductSubProducts_ReturnProducts_ReturnProductId",
                table: "ReturnProductSubProducts",
                column: "ReturnProductId",
                principalTable: "ReturnProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnProductSubProducts_SubProducts_SubProductId",
                table: "ReturnProductSubProducts",
                column: "SubProductId",
                principalTable: "SubProducts",
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
    }
}
