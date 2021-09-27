using Microsoft.EntityFrameworkCore;
using TorneoDeFutbol.App.Dominio;

    namespace TorneoDeFutbol.App.Persistencia
    {
        public class AppContext : DbContext
        {
            public DbSet<Persona> Personas {get; set;}
            public DbSet<Arbitro> Arbitros {get; set;}
            public DbSet<DT> DirectorTecnicos {get; set;}
            public DbSet<Jugador> Jugadores {get; set;}
            public DbSet<Equipo> Equipos {get; set;}
            public DbSet<Municipio> Municipios {get; set;}
            public DbSet<Estadio> Estadios {get; set;}
            public DbSet<Partido> Partidos {get; set;}
            public DbSet<Novedad> Novedades {get; set;}
            public DbSet<Desempeno> Desempeños {get; set;}

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TorneoDeFutbolData");
            }
 
        }
    }
}