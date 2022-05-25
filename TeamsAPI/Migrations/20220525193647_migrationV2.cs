using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamsAPI.Migrations
{
    public partial class migrationV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Teams_location",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_name",
                table: "Teams");

            migrationBuilder.CreateIndex(
                name: "IX_NameAndLocation",
                table: "Teams",
                columns: new[] { "name", "location" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropIndex(
                name: "IX_NameAndLocation",
                table: "Teams");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_location",
                table: "Teams",
                column: "location",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_name",
                table: "Teams",
                column: "name",
                unique: true);
        }
    }
}
