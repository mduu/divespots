using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiveSpots.Drivers.SQL.Migrations
{
    public partial class Add_WaterCountry_Relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                table: "Waters",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Waters_CountryId",
                table: "Waters",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Waters_Countries_CountryId",
                table: "Waters",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Waters_Countries_CountryId",
                table: "Waters");

            migrationBuilder.DropIndex(
                name: "IX_Waters_CountryId",
                table: "Waters");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Waters");
        }
    }
}
