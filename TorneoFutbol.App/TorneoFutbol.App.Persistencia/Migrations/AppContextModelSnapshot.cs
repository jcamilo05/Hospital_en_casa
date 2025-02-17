﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TorneoFutbol.App.Persistencia;

namespace TorneoFutbol.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("TorneoFutbol.App.Dominio.Arbitro", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Colegio")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Documento")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NumeroTelefono")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("ID");

                    b.ToTable("Arbitros");
                });

            modelBuilder.Entity("TorneoFutbol.App.Dominio.DT", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Documento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EquipoID")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroTelefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("EquipoID");

                    b.ToTable("DTs");
                });

            modelBuilder.Entity("TorneoFutbol.App.Dominio.Desempeno", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("GolesAFavor")
                        .HasColumnType("int");

                    b.Property<int>("GolesEnContra")
                        .HasColumnType("int");

                    b.Property<int>("PartidosEmpatados")
                        .HasColumnType("int");

                    b.Property<int>("PartidosGanados")
                        .HasColumnType("int");

                    b.Property<int>("PartidosJugados")
                        .HasColumnType("int");

                    b.Property<int>("Puntos")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Desempenos");
                });

            modelBuilder.Entity("TorneoFutbol.App.Dominio.Equipo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("DesempenoID")
                        .HasColumnType("int");

                    b.Property<int?>("MunicipioID")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DesempenoID");

                    b.HasIndex("MunicipioID");

                    b.ToTable("Equipos");
                });

            modelBuilder.Entity("TorneoFutbol.App.Dominio.Estadio", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Estadios");
                });

            modelBuilder.Entity("TorneoFutbol.App.Dominio.Jugador", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Documento")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("EquipoID")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroTelefono")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("Posicion")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EquipoID");

                    b.ToTable("Jugadores");
                });

            modelBuilder.Entity("TorneoFutbol.App.Dominio.Municipio", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Departamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EstadioID")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("EstadioID");

                    b.ToTable("Municipios");
                });

            modelBuilder.Entity("TorneoFutbol.App.Dominio.Novedad", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("JugadorID")
                        .HasColumnType("int");

                    b.Property<int?>("PartidoID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<int>("TipoNovedad")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("JugadorID");

                    b.HasIndex("PartidoID");

                    b.ToTable("Novedades");
                });

            modelBuilder.Entity("TorneoFutbol.App.Dominio.Partido", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ArbitroID")
                        .HasColumnType("int");

                    b.Property<int?>("EquipoLocalID")
                        .HasColumnType("int");

                    b.Property<int?>("EquipoVisitanteID")
                        .HasColumnType("int");

                    b.Property<int?>("EstadioID")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaHora")
                        .HasColumnType("datetime2");

                    b.Property<int>("MarcadorInicialLocal")
                        .HasColumnType("int");

                    b.Property<int>("MarcadorInicialVisitante")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ArbitroID");

                    b.HasIndex("EquipoLocalID");

                    b.HasIndex("EquipoVisitanteID");

                    b.HasIndex("EstadioID");

                    b.ToTable("Partidos");
                });

            modelBuilder.Entity("TorneoFutbol.App.Dominio.DT", b =>
                {
                    b.HasOne("TorneoFutbol.App.Dominio.Equipo", "Equipo")
                        .WithMany()
                        .HasForeignKey("EquipoID");

                    b.Navigation("Equipo");
                });

            modelBuilder.Entity("TorneoFutbol.App.Dominio.Equipo", b =>
                {
                    b.HasOne("TorneoFutbol.App.Dominio.Desempeno", "Desempeno")
                        .WithMany()
                        .HasForeignKey("DesempenoID");

                    b.HasOne("TorneoFutbol.App.Dominio.Municipio", "Municipio")
                        .WithMany()
                        .HasForeignKey("MunicipioID");

                    b.Navigation("Desempeno");

                    b.Navigation("Municipio");
                });

            modelBuilder.Entity("TorneoFutbol.App.Dominio.Jugador", b =>
                {
                    b.HasOne("TorneoFutbol.App.Dominio.Equipo", "Equipo")
                        .WithMany("Jugadores")
                        .HasForeignKey("EquipoID");

                    b.Navigation("Equipo");
                });

            modelBuilder.Entity("TorneoFutbol.App.Dominio.Municipio", b =>
                {
                    b.HasOne("TorneoFutbol.App.Dominio.Estadio", "Estadio")
                        .WithMany()
                        .HasForeignKey("EstadioID");

                    b.Navigation("Estadio");
                });

            modelBuilder.Entity("TorneoFutbol.App.Dominio.Novedad", b =>
                {
                    b.HasOne("TorneoFutbol.App.Dominio.Jugador", "Jugador")
                        .WithMany("Novedades")
                        .HasForeignKey("JugadorID");

                    b.HasOne("TorneoFutbol.App.Dominio.Partido", "Partido")
                        .WithMany("Novedades")
                        .HasForeignKey("PartidoID");

                    b.Navigation("Jugador");

                    b.Navigation("Partido");
                });

            modelBuilder.Entity("TorneoFutbol.App.Dominio.Partido", b =>
                {
                    b.HasOne("TorneoFutbol.App.Dominio.Arbitro", "Arbitro")
                        .WithMany()
                        .HasForeignKey("ArbitroID");

                    b.HasOne("TorneoFutbol.App.Dominio.Equipo", "EquipoLocal")
                        .WithMany()
                        .HasForeignKey("EquipoLocalID");

                    b.HasOne("TorneoFutbol.App.Dominio.Equipo", "EquipoVisitante")
                        .WithMany()
                        .HasForeignKey("EquipoVisitanteID");

                    b.HasOne("TorneoFutbol.App.Dominio.Estadio", "Estadio")
                        .WithMany()
                        .HasForeignKey("EstadioID");

                    b.Navigation("Arbitro");

                    b.Navigation("EquipoLocal");

                    b.Navigation("EquipoVisitante");

                    b.Navigation("Estadio");
                });

            modelBuilder.Entity("TorneoFutbol.App.Dominio.Equipo", b =>
                {
                    b.Navigation("Jugadores");
                });

            modelBuilder.Entity("TorneoFutbol.App.Dominio.Jugador", b =>
                {
                    b.Navigation("Novedades");
                });

            modelBuilder.Entity("TorneoFutbol.App.Dominio.Partido", b =>
                {
                    b.Navigation("Novedades");
                });
#pragma warning restore 612, 618
        }
    }
}
