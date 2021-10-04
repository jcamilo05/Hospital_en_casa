using System;
using System.Collections.Generic;
namespace TorneoFutbol.App.Dominio
{
     /// <summary>Class <c>Equipo</c>
     /// Modela una Equipo en general en el sistema 
     /// </summary>        
    public class Partido
    {
        // Identificador único de cada persona
        public int ID { get; set; }
        public DateTime FechaHora { get; set; }
        public Equipo EquipoLocal { get; set; }
        public Equipo EquipoVisitante { get; set; }
        public int MarcadorInicialVisitante { get; set; }
        public int MarcadorInicialLocal { get; set; }
        public Estadio Estadio { get; set; }
        public Arbitro Arbitro{ get; set;}
        //se remueve atributo tipo novedad para tener una relacion 1 a muchos con ICollection
        //public Novedad Novedad {get;set;}
        public ICollection<Novedad> Novedades { get; set; }
    }
    
}