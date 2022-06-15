using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NationalBrazilianHolidays.Migrations
{
    public partial class createDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feriados",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ano = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feriados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "localidades",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_localidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Continente",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Continente_localidades_Id",
                        column: x => x.Id,
                        principalTable: "localidades",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Sigla = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContinenteId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pais_Continente_ContinenteId",
                        column: x => x.ContinenteId,
                        principalTable: "Continente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pais_localidades_Id",
                        column: x => x.Id,
                        principalTable: "localidades",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FeriadoPais",
                columns: table => new
                {
                    FeriadosId = table.Column<long>(type: "bigint", nullable: false),
                    PaisesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeriadoPais", x => new { x.FeriadosId, x.PaisesId });
                    table.ForeignKey(
                        name: "FK_FeriadoPais_Feriados_FeriadosId",
                        column: x => x.FeriadosId,
                        principalTable: "Feriados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeriadoPais_Pais_PaisesId",
                        column: x => x.PaisesId,
                        principalTable: "Pais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeriadoPais_PaisesId",
                table: "FeriadoPais",
                column: "PaisesId");

            migrationBuilder.CreateIndex(
                name: "IX_Pais_ContinenteId",
                table: "Pais",
                column: "ContinenteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeriadoPais");

            migrationBuilder.DropTable(
                name: "Feriados");

            migrationBuilder.DropTable(
                name: "Pais");

            migrationBuilder.DropTable(
                name: "Continente");

            migrationBuilder.DropTable(
                name: "localidades");
        }
    }
}
