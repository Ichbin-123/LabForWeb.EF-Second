using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabForWeb.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RelazioniECommenti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AutoreId",
                table: "Articoli",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_Commenti_ArticoloId",
                table: "Commenti",
                column: "ArticoloId");

            migrationBuilder.CreateIndex(
                name: "IX_Commenti_AutoreId",
                table: "Commenti",
                column: "AutoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articoli_Utenti_AutoreId",
                table: "Articoli",
                column: "AutoreId",
                principalTable: "Utenti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articoli_Utenti_AutoreId",
                table: "Articoli");

            migrationBuilder.DropTable(
                name: "Commenti");

            migrationBuilder.DropIndex(
                name: "IX_Articoli_AutoreId",
                table: "Articoli");

            migrationBuilder.DropColumn(
                name: "AutoreId",
                table: "Articoli");
        }
    }
}
