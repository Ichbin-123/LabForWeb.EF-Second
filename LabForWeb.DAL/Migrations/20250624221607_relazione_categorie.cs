using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabForWeb.DAL.Migrations
{
    /// <inheritdoc />
    public partial class relazione_categorie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_ArticoloCategoria_CategorieId",
                table: "ArticoloCategoria",
                column: "CategorieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticoloCategoria");
        }
    }
}
