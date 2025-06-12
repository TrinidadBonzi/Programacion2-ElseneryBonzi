using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Veterinaria.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Duenios",
                columns: table => new
                {
                    idDuenio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dniDuenio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombreDuenio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellidoDuenio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_DUENIO", x => x.idDuenio);
                });

            migrationBuilder.CreateTable(
                name: "Animales",
                columns: table => new
                {
                    idAnimal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreAnimal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    razaAnimal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    edadAnimal = table.Column<int>(type: "int", nullable: false),
                    sexoAnimal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idDuenio = table.Column<int>(type: "int", nullable: true),
                    DuenioidDuenio = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_ANIMAL", x => x.idAnimal);
                    table.ForeignKey(
                        name: "FK_Animales_Duenios_DuenioidDuenio",
                        column: x => x.DuenioidDuenio,
                        principalTable: "Duenios",
                        principalColumn: "idDuenio");
                    table.ForeignKey(
                        name: "FK_Animales_Duenios_idDuenio",
                        column: x => x.idDuenio,
                        principalTable: "Duenios",
                        principalColumn: "idDuenio");
                });

            migrationBuilder.CreateTable(
                name: "Atenciones",
                columns: table => new
                {
                    idAtencion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaAtencion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    motivoAtencion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tratamientoAtencion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    medicamentoAtencion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaRegistroAtencion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idAnimal = table.Column<int>(type: "int", nullable: false),
                    AnimalidAnimal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_ATENCION", x => x.idAtencion);
                    table.ForeignKey(
                        name: "FK_Atenciones_Animales_AnimalidAnimal",
                        column: x => x.AnimalidAnimal,
                        principalTable: "Animales",
                        principalColumn: "idAnimal");
                    table.ForeignKey(
                        name: "FK_Atenciones_Animales_idAnimal",
                        column: x => x.idAnimal,
                        principalTable: "Animales",
                        principalColumn: "idAnimal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animales_DuenioidDuenio",
                table: "Animales",
                column: "DuenioidDuenio");

            migrationBuilder.CreateIndex(
                name: "IX_Animales_idDuenio",
                table: "Animales",
                column: "idDuenio");

            migrationBuilder.CreateIndex(
                name: "IX_Atenciones_AnimalidAnimal",
                table: "Atenciones",
                column: "AnimalidAnimal");

            migrationBuilder.CreateIndex(
                name: "IX_Atenciones_idAnimal",
                table: "Atenciones",
                column: "idAnimal");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atenciones");

            migrationBuilder.DropTable(
                name: "Animales");

            migrationBuilder.DropTable(
                name: "Duenios");
        }
    }
}
