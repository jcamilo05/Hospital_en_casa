using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TorneoFutbol.App.Persistencia.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Desempenios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartidosJugados = table.Column<int>(type: "int", nullable: false),
                    PartidosGanados = table.Column<int>(type: "int", nullable: false),
                    PartidosEmpatados = table.Column<int>(type: "int", nullable: false),
                    GolesAFavor = table.Column<int>(type: "int", nullable: false),
                    GolesEnContra = table.Column<int>(type: "int", nullable: false),
                    Puntos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desempenios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Estadios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estadios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Novedades",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TarjetaAmarilla = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TarjetaRoja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Novedades", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Departamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadioID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Municipios_Estadios_EstadioID",
                        column: x => x.EstadioID,
                        principalTable: "Estadios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Equipos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DirectorID = table.Column<int>(type: "int", nullable: true),
                    MunicipioID = table.Column<int>(type: "int", nullable: true),
                    DesempenioID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Equipos_Desempenios_DesempenioID",
                        column: x => x.DesempenioID,
                        principalTable: "Desempenios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipos_Municipios_MunicipioID",
                        column: x => x.MunicipioID,
                        principalTable: "Municipios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroTelefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colegio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Posicion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EquipoID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Personas_Equipos_EquipoID",
                        column: x => x.EquipoID,
                        principalTable: "Equipos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Partidos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EquipoLocalID = table.Column<int>(type: "int", nullable: true),
                    EquipoVisitanteID = table.Column<int>(type: "int", nullable: true),
                    MarcadorInicialVisitante = table.Column<int>(type: "int", nullable: false),
                    MarcadorInicialLocal = table.Column<int>(type: "int", nullable: false),
                    EstadioID = table.Column<int>(type: "int", nullable: true),
                    ArbitroID = table.Column<int>(type: "int", nullable: true),
                    NovedadID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Partidos_Equipos_EquipoLocalID",
                        column: x => x.EquipoLocalID,
                        principalTable: "Equipos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partidos_Equipos_EquipoVisitanteID",
                        column: x => x.EquipoVisitanteID,
                        principalTable: "Equipos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partidos_Estadios_EstadioID",
                        column: x => x.EstadioID,
                        principalTable: "Estadios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partidos_Novedades_NovedadID",
                        column: x => x.NovedadID,
                        principalTable: "Novedades",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partidos_Personas_ArbitroID",
                        column: x => x.ArbitroID,
                        principalTable: "Personas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_DesempenioID",
                table: "Equipos",
                column: "DesempenioID");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_DirectorID",
                table: "Equipos",
                column: "DirectorID");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_MunicipioID",
                table: "Equipos",
                column: "MunicipioID");

            migrationBuilder.CreateIndex(
                name: "IX_Municipios_EstadioID",
                table: "Municipios",
                column: "EstadioID");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_ArbitroID",
                table: "Partidos",
                column: "ArbitroID");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_EquipoLocalID",
                table: "Partidos",
                column: "EquipoLocalID");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_EquipoVisitanteID",
                table: "Partidos",
                column: "EquipoVisitanteID");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_EstadioID",
                table: "Partidos",
                column: "EstadioID");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_NovedadID",
                table: "Partidos",
                column: "NovedadID");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_EquipoID",
                table: "Personas",
                column: "EquipoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipos_Personas_DirectorID",
                table: "Equipos",
                column: "DirectorID",
                principalTable: "Personas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipos_Desempenios_DesempenioID",
                table: "Equipos");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipos_Municipios_MunicipioID",
                table: "Equipos");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipos_Personas_DirectorID",
                table: "Equipos");

            migrationBuilder.DropTable(
                name: "Partidos");

            migrationBuilder.DropTable(
                name: "Novedades");

            migrationBuilder.DropTable(
                name: "Desempenios");

            migrationBuilder.DropTable(
                name: "Municipios");

            migrationBuilder.DropTable(
                name: "Estadios");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Equipos");
        }
    }
}
