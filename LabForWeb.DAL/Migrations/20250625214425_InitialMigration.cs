using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabForWeb.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utenti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articoli",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titolo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Testo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AutoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articoli", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articoli_Utenti_AutoreId",
                        column: x => x.AutoreId,
                        principalTable: "Utenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticoloCategoria",
                columns: table => new
                {
                    ArticoliId = table.Column<int>(type: "int", nullable: false),
                    CategorieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticoloCategoria", x => new { x.ArticoliId, x.CategorieId });
                    table.ForeignKey(
                        name: "FK_ArticoloCategoria_Articoli_ArticoliId",
                        column: x => x.ArticoliId,
                        principalTable: "Articoli",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticoloCategoria_Categorie_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticoloTag",
                columns: table => new
                {
                    ArticoloId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DataAssociazione = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticoloTag", x => new { x.TagId, x.ArticoloId });
                    table.ForeignKey(
                        name: "FK_ArticoloTag_Articoli_ArticoloId",
                        column: x => x.ArticoloId,
                        principalTable: "Articoli",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticoloTag_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Testo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    AutoreId = table.Column<int>(type: "int", nullable: false),
                    ArticoloId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commenti_Articoli_ArticoloId",
                        column: x => x.ArticoloId,
                        principalTable: "Articoli",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Commenti_Utenti_AutoreId",
                        column: x => x.AutoreId,
                        principalTable: "Utenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articoli_AutoreId",
                table: "Articoli",
                column: "AutoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticoloCategoria_CategorieId",
                table: "ArticoloCategoria",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticoloTag_ArticoloId",
                table: "ArticoloTag",
                column: "ArticoloId");

            migrationBuilder.CreateIndex(
                name: "IX_Commenti_ArticoloId",
                table: "Commenti",
                column: "ArticoloId");

            migrationBuilder.CreateIndex(
                name: "IX_Commenti_AutoreId",
                table: "Commenti",
                column: "AutoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticoloCategoria");

            migrationBuilder.DropTable(
                name: "ArticoloTag");

            migrationBuilder.DropTable(
                name: "Commenti");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Articoli");

            migrationBuilder.DropTable(
                name: "Utenti");
        }
    }
}
