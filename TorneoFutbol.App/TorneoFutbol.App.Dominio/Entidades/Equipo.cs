using System;
using System.Collections.Generic;
namespace TorneoFutbol.App.Dominio
{
     /// <summary>Class <c>Equipo</c>
     /// Modela una Equipo en general en el sistema 
     /// </summary>        
    public class Equipo
    {
        // Identificador único de cada persona
        public int ID { get; set; }
        public string Nombre { get; set; }
        public DT Director { get; set; }
        public Municipio Municipio { get; set; } 
        public Desempenio Desempenio {get;set;}
        public virtual ICollection<Jugador> Jugadores { get; set; } 
        
    }
}