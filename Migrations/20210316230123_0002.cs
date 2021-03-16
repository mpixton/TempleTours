using Microsoft.EntityFrameworkCore.Migrations;

namespace TempleTours.Migrations
{
    public partial class _0002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourParty_Tours_TourId",
                table: "TourParty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TourParty",
                table: "TourParty");

            migrationBuilder.RenameTable(
                name: "TourParty",
                newName: "Parties");

            migrationBuilder.RenameIndex(
                name: "IX_TourParty_TourId",
                table: "Parties",
                newName: "IX_Parties_TourId");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Parties",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Parties",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parties",
                table: "Parties",
                column: "TourPartyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parties_Tours_TourId",
                table: "Parties",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "TourId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parties_Tours_TourId",
                table: "Parties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parties",
                table: "Parties");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Parties");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Parties");

            migrationBuilder.RenameTable(
                name: "Parties",
                newName: "TourParty");

            migrationBuilder.RenameIndex(
                name: "IX_Parties_TourId",
                table: "TourParty",
                newName: "IX_TourParty_TourId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TourParty",
                table: "TourParty",
                column: "TourPartyId");

            migrationBuilder.AddForeignKey(
                name: "FK_TourParty_Tours_TourId",
                table: "TourParty",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "TourId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
