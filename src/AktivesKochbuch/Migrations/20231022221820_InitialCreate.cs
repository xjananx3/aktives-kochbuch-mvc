using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AktivesKochbuch.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Benutzer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Benutzername = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benutzer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vorschläge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Wochentag = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    RezeptId = table.Column<int>(type: "INTEGER", nullable: false),
                    AnzahlVorschläge = table.Column<int>(type: "INTEGER", nullable: false),
                    BenutzerId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vorschläge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vorschläge_Benutzer_BenutzerId",
                        column: x => x.BenutzerId,
                        principalTable: "Benutzer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rezepte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RezeptTitel = table.Column<string>(type: "TEXT", nullable: false),
                    Zubereitung = table.Column<string>(type: "TEXT", nullable: false),
                    RezeptKategorie = table.Column<int>(type: "INTEGER", nullable: false),
                    BenutzerId = table.Column<int>(type: "INTEGER", nullable: true),
                    VorschlagId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezepte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezepte_Benutzer_BenutzerId",
                        column: x => x.BenutzerId,
                        principalTable: "Benutzer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rezepte_Vorschläge_VorschlagId",
                        column: x => x.VorschlagId,
                        principalTable: "Vorschläge",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rezepte_BenutzerId",
                table: "Rezepte",
                column: "BenutzerId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezepte_VorschlagId",
                table: "Rezepte",
                column: "VorschlagId");

            migrationBuilder.CreateIndex(
                name: "IX_Vorschläge_BenutzerId",
                table: "Vorschläge",
                column: "BenutzerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rezepte");

            migrationBuilder.DropTable(
                name: "Vorschläge");

            migrationBuilder.DropTable(
                name: "Benutzer");
        }
    }
}
