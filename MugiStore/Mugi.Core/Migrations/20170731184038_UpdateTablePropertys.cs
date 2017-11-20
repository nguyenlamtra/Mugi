using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mugi.Core.Migrations
{
    public partial class UpdateTablePropertys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyDetails_Property_PropertyId",
                table: "PropertyDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyProducts_Property_PropertiesId",
                table: "PropertyProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Property",
                table: "Property");

            migrationBuilder.RenameTable(
                name: "Property",
                newName: "Propertys");

            migrationBuilder.RenameColumn(
                name: "PropertiesId",
                table: "PropertyProducts",
                newName: "PropertyId");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyProducts_PropertiesId",
                table: "PropertyProducts",
                newName: "IX_PropertyProducts_PropertyId");

            migrationBuilder.RenameColumn(
                name: "PropertiesName",
                table: "Propertys",
                newName: "PropertyName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Propertys",
                table: "Propertys",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyDetails_Propertys_PropertyId",
                table: "PropertyDetails",
                column: "PropertyId",
                principalTable: "Propertys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyProducts_Propertys_PropertyId",
                table: "PropertyProducts",
                column: "PropertyId",
                principalTable: "Propertys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyDetails_Propertys_PropertyId",
                table: "PropertyDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyProducts_Propertys_PropertyId",
                table: "PropertyProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Propertys",
                table: "Propertys");

            migrationBuilder.RenameTable(
                name: "Propertys",
                newName: "Property");

            migrationBuilder.RenameColumn(
                name: "PropertyId",
                table: "PropertyProducts",
                newName: "PropertiesId");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyProducts_PropertyId",
                table: "PropertyProducts",
                newName: "IX_PropertyProducts_PropertiesId");

            migrationBuilder.RenameColumn(
                name: "PropertyName",
                table: "Property",
                newName: "PropertiesName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Property",
                table: "Property",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyDetails_Property_PropertyId",
                table: "PropertyDetails",
                column: "PropertyId",
                principalTable: "Property",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyProducts_Property_PropertiesId",
                table: "PropertyProducts",
                column: "PropertiesId",
                principalTable: "Property",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
