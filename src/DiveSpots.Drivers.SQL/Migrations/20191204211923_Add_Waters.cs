using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiveSpots.Drivers.SQL.Migrations
{
    public partial class Add_Waters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Waters",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    JsonData = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waters", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Waters");
        }
    }
}
