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
                    ArbitroID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroTelefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Colegio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arbitros", x => x.ArbitroID);
                });

            migrationBuilder.CreateTable(
                name: "Desempenos",
                columns: table => new
                {
                    DesempenoID = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_Desempenos", x => x.DesempenoID);
                });

            migrationBuilder.CreateTable(
                name: "DTs",
                columns: table => new
                {
                    DtID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroTelefono = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DTs", x => x.DtID);
                });

            migrationBuilder.CreateTable(
                name: "Estadios",
                columns: table => new
                {
                    EstadioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estadios", x => x.EstadioID);
                });

            migrationBuilder.CreateTable(
                name: "Novedades",
                columns: table => new
                {
                    NovedadID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TarjetaAmarilla = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TarjetaRoja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Novedades", x => x.NovedadID);
                });

            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    MunicipioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Departamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.MunicipioID);
                    table.ForeignKey(
                        name: "FK_Municipios_Estadios_EstadioId",
                        column: x => x.EstadioId,
                        principalTable: "Estadios",
                        principalColumn: "EstadioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipos",
                columns: table => new
                {
                    EquipoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Local = table.Column<bool>(type: "bit", nullable: false),
                    DtID = table.Column<int>(type: "int", nullable: false),
                    MunicipioID = table.Column<int>(type: "int", nullable: false),
                    DesempenoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipos", x => x.EquipoID);
                    table.ForeignKey(
                        name: "FK_Equipos_Desempenos_DesempenoID",
                        column: x => x.DesempenoID,
                        principalTable: "Desempenos",
                        principalColumn: "DesempenoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipos_DTs_DtID",
                        column: x => x.DtID,
                        principalTable: "DTs",
                        principalColumn: "DtID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipos_Municipios_MunicipioID",
                        column: x => x.MunicipioID,
                        principalTable: "Municipios",
                        principalColumn: "MunicipioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jugadores",
                columns: table => new
                {
                    JugadorID = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_Jugadores", x => x.JugadorID);
                    table.ForeignKey(
                        name: "FK_Jugadores_Equipos_EquipoID",
                        column: x => x.EquipoID,
                        principalTable: "Equipos",
                        principalColumn: "EquipoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Partidos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MarcadorInicial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarcadorFinal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EquipoID = table.Column<int>(type: "int", nullable: false),
                    ArbitroID = table.Column<int>(type: "int", nullable: false),
                    NovedadID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Partidos_Arbitros_ArbitroID",
                        column: x => x.ArbitroID,
                        principalTable: "Arbitros",
                        principalColumn: "ArbitroID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Partidos_Equipos_EquipoID",
                        column: x => x.EquipoID,
                        principalTable: "Equipos",
                        principalColumn: "EquipoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Partidos_Novedades_NovedadID",
                        column: x => x.NovedadID,
                        principalTable: "Novedades",
                        principalColumn: "NovedadID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_DesempenoID",
                table: "Equipos",
                column: "DesempenoID");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_DtID",
                table: "Equipos",
                column: "DtID");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_MunicipioID",
                table: "Equipos",
                column: "MunicipioID");

            migrationBuilder.CreateIndex(
                name: "IX_Jugadores_EquipoID",
                table: "Jugadores",
                column: "EquipoID");

            migrationBuilder.CreateIndex(
                name: "IX_Municipios_EstadioId",
                table: "Municipios",
                column: "EstadioId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_ArbitroID",
                table: "Partidos",
                column: "ArbitroID");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_EquipoID",
                table: "Partidos",
                column: "EquipoID");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_NovedadID",
                table: "Partidos",
                column: "NovedadID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jugadores");

            migrationBuilder.DropTable(
                name: "Partidos");

            migrationBuilder.DropTable(
                name: "Arbitros");

            migrationBuilder.DropTable(
                name: "Equipos");

            migrationBuilder.DropTable(
                name: "Novedades");

            migrationBuilder.DropTable(
                name: "Desempenos");

            migrationBuilder.DropTable(
                name: "DTs");

            migrationBuilder.DropTable(
                name: "Municipios");

            migrationBuilder.DropTable(
                name: "Estadios");
        }
    }
}
