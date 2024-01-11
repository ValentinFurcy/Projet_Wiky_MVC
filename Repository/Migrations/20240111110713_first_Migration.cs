using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class first_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Auteur = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Contenu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Auteur = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Contenu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ArticleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Articles_ArticleID",
                        column: x => x.ArticleID,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Auteur", "Contenu", "DateCreate", "DateModified", "Theme" },
                values: new object[,]
                {
                    { 1, "Valentin", "Je préfére les animaux aux humains car ils sont fidéles", new DateTime(2024, 1, 11, 12, 7, 13, 705, DateTimeKind.Local).AddTicks(2606), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Animaux" },
                    { 2, "Valentin", "En développement tester s'est douter !!!", new DateTime(2024, 1, 11, 12, 7, 13, 705, DateTimeKind.Local).AddTicks(2650), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Code" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ArticleID",
                table: "Comments",
                column: "ArticleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}
