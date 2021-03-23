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
                name: "Parties",
                columns: table => new
                {
                    TourPartyId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TourId = table.Column<int>(type: "INTEGER", nullable: false),
                    PartyName = table.Column<string>(type: "TEXT", nullable: false),
                    PartySize = table.Column<int>(type: "INTEGER", nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parties", x => x.TourPartyId);
                    table.ForeignKey(
                        name: "FK_Parties_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "TourId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parties_TourId",
                table: "Parties",
                column: "TourId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parties");

            migrationBuilder.DropTable(
                name: "Tours");
        }
    }
}
