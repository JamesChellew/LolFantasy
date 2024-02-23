using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LolFantasy.Migrations
{
    public partial class UpdatedPlayersAndTeams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeamName",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_TeamId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "TeamName",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Players");
        }
    }
}
