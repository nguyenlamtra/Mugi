using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mugi.Core.Migrations
{
    public partial class AddTablePropertiesProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_PropertiesProducts_PropertiesId",
                table: "PropertiesProducts",
                column: "PropertiesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertiesProducts");

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
        }
    }
}
