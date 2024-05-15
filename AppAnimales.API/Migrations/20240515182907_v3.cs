using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppAnimales.API.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GrupoId",
                table: "Animales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Animales_GrupoId",
                table: "Animales",
                column: "GrupoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animales_Grupos_GrupoId",
                table: "Animales",
                column: "GrupoId",
                principalTable: "Grupos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animales_Grupos_GrupoId",
                table: "Animales");

            migrationBuilder.DropIndex(
                name: "IX_Animales_GrupoId",
                table: "Animales");

            migrationBuilder.DropColumn(
                name: "GrupoId",
                table: "Animales");
        }
    }
}
