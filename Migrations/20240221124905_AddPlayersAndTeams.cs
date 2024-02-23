using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LolFantasy.Migrations
{
    public partial class AddPlayersAndTeams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedTime", "Email", "FirstName", "LastName", "PhoneNumber", "PhotoUrl", "UpdateTime" },
                values: new object[] { 1, new DateTime(2024, 2, 20, 16, 0, 35, 951, DateTimeKind.Local).AddTicks(8039), "Jamespchellew@outlook.com", "James", "Chellew", "0432665009", "", new DateTime(2024, 2, 20, 16, 0, 35, 951, DateTimeKind.Local).AddTicks(8047) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedTime", "Email", "FirstName", "LastName", "PhoneNumber", "PhotoUrl", "UpdateTime" },
                values: new object[] { 2, new DateTime(2024, 2, 20, 16, 0, 35, 951, DateTimeKind.Local).AddTicks(8049), "Ash@outlook.com", "Ash", "T", "0412312312", "", new DateTime(2024, 2, 20, 16, 0, 35, 951, DateTimeKind.Local).AddTicks(8050) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedTime", "Email", "FirstName", "LastName", "PhoneNumber", "PhotoUrl", "UpdateTime" },
                values: new object[] { 3, new DateTime(2024, 2, 20, 16, 0, 35, 951, DateTimeKind.Local).AddTicks(8055), "Liam@outlook.com", "Liam", "p", "0409987987", "", new DateTime(2024, 2, 20, 16, 0, 35, 951, DateTimeKind.Local).AddTicks(8055) });
        }
    }
}
