using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TorneoFutbol.App.Persistencia.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arbitros",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroTelefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Colegio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arbitros", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Desempenos",
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
                    table.PrimaryKey("PK_Desempenos", x => x.ID);
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
                    MunicipioID = table.Column<int>(type: "int", nullable: true),
                    DesempenoID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Equipos_Desempenos_DesempenoID",
                        column: x => x.DesempenoID,
                        principalTable: "Desempenos",
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
                name: "DTs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroTelefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EquipoID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DTs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DTs_Equipos_EquipoID",
                        column: x => x.EquipoID,
                        principalTable: "Equipos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Jugadores",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroTelefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Posicion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EquipoID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugadores", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Jugadores_Equipos_EquipoID",
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
                    ArbitroID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Partidos_Arbitros_ArbitroID",
                        column: x => x.ArbitroID,
                        principalTable: "Arbitros",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
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
                });

            migrationBuilder.CreateTable(
                name: "Novedades",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoNovedad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JugadorID = table.Column<int>(type: "int", nullable: true),
                    PartidoID = table.Column<int>(type: "int", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Novedades", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Novedades_Jugadores_JugadorID",
                        column: x => x.JugadorID,
                        principalTable: "Jugadores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Novedades_Partidos_PartidoID",
                        column: x => x.PartidoID,
                        principalTable: "Partidos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DTs_EquipoID",
                table: "DTs",
                column: "EquipoID");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_DesempenoID",
                table: "Equipos",
                column: "DesempenoID");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_MunicipioID",
                table: "Equipos",
                column: "MunicipioID");

            migrationBuilder.CreateIndex(
                name: "IX_Jugadores_EquipoID",
                table: "Jugadores",
                column: "EquipoID");

            migrationBuilder.CreateIndex(
                name: "IX_Municipios_EstadioID",
                table: "Municipios",
                column: "EstadioID");

            migrationBuilder.CreateIndex(
                name: "IX_Novedades_JugadorID",
                table: "Novedades",
                column: "JugadorID");

            migrationBuilder.CreateIndex(
                name: "IX_Novedades_PartidoID",
                table: "Novedades",
                column: "PartidoID");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DTs");

            migrationBuilder.DropTable(
                name: "Novedades");

            migrationBuilder.DropTable(
                name: "Jugadores");

            migrationBuilder.DropTable(
                name: "Partidos");

            migrationBuilder.DropTable(
                name: "Arbitros");

            migrationBuilder.DropTable(
                name: "Equipos");

            migrationBuilder.DropTable(
                name: "Desempenos");

            migrationBuilder.DropTable(
                name: "Municipios");

            migrationBuilder.DropTable(
                name: "Estadios");
        }
    }
}
