using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Veterinaria.Migrations
{
    /// <inheritdoc />
    public partial class all : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animales_Duenios_DuenioidDuenio",
                table: "Animales");

            migrationBuilder.DropIndex(
                name: "IX_Animales_DuenioidDuenio",
                table: "Animales");

            migrationBuilder.DropColumn(
                name: "DuenioidDuenio",
                table: "Animales");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DuenioidDuenio",
                table: "Animales",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Animales_DuenioidDuenio",
                table: "Animales",
                column: "DuenioidDuenio");

            migrationBuilder.AddForeignKey(
                name: "FK_Animales_Duenios_DuenioidDuenio",
                table: "Animales",
                column: "DuenioidDuenio",
                principalTable: "Duenios",
                principalColumn: "idDuenio");
        }
    }
}
