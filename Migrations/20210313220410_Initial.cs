using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TempleTours.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    TourId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TourTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.TourId);
                });

            migrationBuilder.CreateTable(
                name: "TourParty",
                columns: table => new
                {
                    TourPartyId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    PartySize = table.Column<int>(type: "INTEGER", nullable: false),
                    TourId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourParty", x => x.TourPartyId);
                    table.ForeignKey(
                        name: "FK_TourParty_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "TourId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TourParty_TourId",
                table: "TourParty",
                column: "TourId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TourParty");

            migrationBuilder.DropTable(
                name: "Tours");
        }
    }
}
