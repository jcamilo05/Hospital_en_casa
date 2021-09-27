using Microsoft.EntityFrameworkCore.Migrations;

namespace TorneoFutbol.App.Persistencia.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipos_Personas_DirectorID",
                table: "Equipos");

            migrationBuilder.DropForeignKey(
                name: "FK_Partidos_Personas_ArbitroID",
                table: "Partidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Equipos_EquipoID",
                table: "Personas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personas",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Colegio",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Personas");

            migrationBuilder.RenameTable(
                name: "Personas",
                newName: "Jugadores");

            migrationBuilder.RenameIndex(
                name: "IX_Personas_EquipoID",
                table: "Jugadores",
                newName: "IX_Jugadores_EquipoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jugadores",
                table: "Jugadores",
                column: "ID");

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
                name: "DTs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroTelefono = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DTs", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Equipos_DTs_DirectorID",
                table: "Equipos",
                column: "DirectorID",
                principalTable: "DTs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jugadores_Equipos_EquipoID",
                table: "Jugadores",
                column: "EquipoID",
                principalTable: "Equipos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Partidos_Arbitros_ArbitroID",
                table: "Partidos",
                column: "ArbitroID",
                principalTable: "Arbitros",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipos_DTs_DirectorID",
                table: "Equipos");

            migrationBuilder.DropForeignKey(
                name: "FK_Jugadores_Equipos_EquipoID",
                table: "Jugadores");

            migrationBuilder.DropForeignKey(
                name: "FK_Partidos_Arbitros_ArbitroID",
                table: "Partidos");

            migrationBuilder.DropTable(
                name: "Arbitros");

            migrationBuilder.DropTable(
                name: "DTs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jugadores",
                table: "Jugadores");

            migrationBuilder.RenameTable(
                name: "Jugadores",
                newName: "Personas");

            migrationBuilder.RenameIndex(
                name: "IX_Jugadores_EquipoID",
                table: "Personas",
                newName: "IX_Personas_EquipoID");

            migrationBuilder.AddColumn<string>(
                name: "Colegio",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personas",
                table: "Personas",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipos_Personas_DirectorID",
                table: "Equipos",
                column: "DirectorID",
                principalTable: "Personas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Partidos_Personas_ArbitroID",
                table: "Partidos",
                column: "ArbitroID",
                principalTable: "Personas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Equipos_EquipoID",
                table: "Personas",
                column: "EquipoID",
                principalTable: "Equipos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
