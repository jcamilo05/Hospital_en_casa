using Microsoft.EntityFrameworkCore;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
   public class AppContext : DbContext
    {
        public DbSet<Arbitro> Arbitros {get; set;}
        public DbSet<DT> DTs {get; set;}
        public DbSet<Jugador> Jugadores {get; set;}
        public DbSet<Equipo> Equipos {get; set;}
        public DbSet<Municipio> Municipios {get; set;}
        public DbSet<Estadio> Estadios {get; set;}
        public DbSet<Partido> Partidos {get; set;}
        public DbSet<Novedad> Novedades {get; set;}
        public DbSet<Desempeno> Desempenos {get; set;}

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TorneoFutbol");
                //linea de conexion a db remota
                //optionsBuilder.UseSqlServer("Data Source=SQL5104.site4now.net;Initial Catalog=db_a7adac_torneofutbol;User Id=db_a7adac_torneofutbol_admin;Password=MisionTic4");
            }
 
        }
    }
}