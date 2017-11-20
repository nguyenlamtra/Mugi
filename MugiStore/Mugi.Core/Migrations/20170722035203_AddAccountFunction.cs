using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mugi.Core.Migrations
{
    public partial class AddAccountFunction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Staffs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "OrderSubProducts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Customers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RoleAccounts",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false),
                    AccountId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleAccounts", x => new { x.RoleId, x.AccountId });
                    table.ForeignKey(
                        name: "FK_RoleAccounts_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleAccounts_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_AccountId",
                table: "Staffs",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AccountId",
                table: "Customers",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleAccounts_AccountId",
                table: "RoleAccounts",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Accounts_AccountId",
                table: "Customers",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Accounts_AccountId",
                table: "Staffs",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Accounts_AccountId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Accounts_AccountId",
                table: "Staffs");

            migrationBuilder.DropTable(
                name: "RoleAccounts");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_AccountId",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Customers_AccountId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "OrderSubProducts");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Staffs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Customers",
                nullable: true);
        }
    }
}
