using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiveSpots.Drivers.SQL.Migrations
{
    public partial class Add_Spots : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spots",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    JsonData = table.Column<string>(nullable: false),
                    WaterId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spots_Waters_WaterId",
                        column: x => x.WaterId,
                        principalTable: "Waters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Spots_WaterId",
                table: "Spots",
                column: "WaterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spots");
        }
    }
}
