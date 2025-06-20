using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kol2.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Maps",
                columns: table => new
                {
                    MapId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maps", x => x.MapId);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    MatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentId = table.Column<int>(type: "int", nullable: false),
                    MapId = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Team1Score = table.Column<int>(type: "int", nullable: false),
                    Team2Score = table.Column<int>(type: "int", nullable: false),
                    BestRating = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.MatchId);
                });

            migrationBuilder.CreateTable(
                name: "PlayerMatches",
                columns: table => new
                {
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    Mvps = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerMatches", x => new { x.MatchId, x.PlayerId });
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    TournamentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.TournamentId);
                });

            migrationBuilder.InsertData(
                table: "Maps",
                columns: new[] { "MapId", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "costam", "classic" },
                    { 2, "cosinnego", "war" }
                });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "MatchId", "BestRating", "DateTime", "MapId", "Team1Score", "Team2Score", "TournamentId" },
                values: new object[,]
                {
                    { 1, 4m, new DateTime(2025, 6, 10, 12, 43, 21, 554, DateTimeKind.Local).AddTicks(7057), 1, 1, 3, 1 },
                    { 2, 2m, new DateTime(2025, 6, 10, 12, 43, 21, 556, DateTimeKind.Local).AddTicks(3635), 2, 5, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "PlayerMatches",
                columns: new[] { "MatchId", "PlayerId", "Mvps", "Rating" },
                values: new object[,]
                {
                    { 1, 1, 1, 2m },
                    { 2, 2, 2, 2m }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerId", "BirthDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 10, 12, 43, 21, 556, DateTimeKind.Local).AddTicks(5053), "John", "Smith" },
                    { 2, new DateTime(2025, 6, 10, 12, 43, 21, 556, DateTimeKind.Local).AddTicks(5293), "Simon", "High" }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "TournamentId", "EndDate", "Name", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 17, 12, 43, 21, 556, DateTimeKind.Local).AddTicks(8082), "BigOne", new DateTime(2025, 6, 10, 12, 43, 21, 556, DateTimeKind.Local).AddTicks(7861) },
                    { 2, new DateTime(2025, 6, 17, 12, 43, 21, 556, DateTimeKind.Local).AddTicks(8327), "Small", new DateTime(2025, 6, 10, 12, 43, 21, 556, DateTimeKind.Local).AddTicks(8319) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Maps");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "PlayerMatches");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Tournaments");
        }
    }
}
