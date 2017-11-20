using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mugi.Core.Migrations
{
    public partial class UpdateTableProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_PropertiesDetailsSubProducts_SubProductId",
                table: "PropertiesDetailsSubProducts",
                column: "SubProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertiesDetailsSubProducts");
        }
    }
}
