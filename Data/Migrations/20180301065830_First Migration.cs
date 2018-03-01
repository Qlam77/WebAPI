using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SQLiteWeb.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropIndex(
            //    name: "IX_AspNetUserRoles_UserId",
            //    table: "AspNetUserRoles");

            //migrationBuilder.DropIndex(
            //    name: "RoleNameIndex",
            //    table: "AspNetRoles");

            migrationBuilder.CreateTable(
                name: "Standings",
                columns: table => new
                {
                    StandingsId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Bronze = table.Column<int>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    Gold = table.Column<int>(nullable: false),
                    Rank = table.Column<int>(nullable: false),
                    Silver = table.Column<int>(nullable: false),
                    Total = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Standings", x => x.StandingsId);
                });

            //migrationBuilder.CreateIndex(
            //    name: "RoleNameIndex",
            //    table: "AspNetRoles",
            //    column: "NormalizedName",
            //    unique: true);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_AspNetUserTokens_AspNetUsers_UserId",
            //    table: "AspNetUserTokens",
            //    column: "UserId",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_AspNetUserTokens_AspNetUsers_UserId",
            //    table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Standings");

            //migrationBuilder.DropIndex(
            //    name: "RoleNameIndex",
            //    table: "AspNetRoles");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserRoles_UserId",
            //    table: "AspNetUserRoles",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "RoleNameIndex",
            //    table: "AspNetRoles",
            //    column: "NormalizedName");
        }
    }
}
