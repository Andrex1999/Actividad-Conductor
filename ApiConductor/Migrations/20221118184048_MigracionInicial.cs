using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiConductor.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "matricula",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(nullable: true),
                    FechaExpedicion = table.Column<DateTime>(nullable: false),
                    FechadeExpiracion = table.Column<DateTime>(nullable: false),
                    Activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_matricula", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "conductor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificacion = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(maxLength: 15, nullable: true),
                    Direccion = table.Column<string>(maxLength: 20, nullable: false),
                    Telefono = table.Column<string>(maxLength: 30, nullable: false),
                    Email = table.Column<string>(maxLength: 15, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(maxLength: 30, nullable: false),
                    Activo = table.Column<bool>(nullable: false),
                    MatriculaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conductor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_conductor_matricula_MatriculaId",
                        column: x => x.MatriculaId,
                        principalTable: "matricula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sanciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaActual = table.Column<DateTime>(nullable: false),
                    ConductorId = table.Column<string>(nullable: false),
                    Identificacion = table.Column<int>(nullable: true),
                    Sancion = table.Column<string>(nullable: true),
                    Observacion = table.Column<string>(maxLength: 100, nullable: false),
                    Valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sanciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sanciones_conductor_Identificacion",
                        column: x => x.Identificacion,
                        principalTable: "conductor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_conductor_MatriculaId",
                table: "conductor",
                column: "MatriculaId");

            migrationBuilder.CreateIndex(
                name: "IX_sanciones_Identificacion",
                table: "sanciones",
                column: "Identificacion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sanciones");

            migrationBuilder.DropTable(
                name: "conductor");

            migrationBuilder.DropTable(
                name: "matricula");
        }
    }
}
