using System;
using System.Collections.Generic;
namespace TorneoDeFutbol.App.Dominio
{
     /// <summary>Class <c>Equipo</c>
     /// Modela una Equipo en general en el sistema 
     /// </summary>        
    public class Equipo
    {
        // Identificador único de cada persona
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<DT> Director { get; set; }
        public List<Municipio> Municipio { get; set; } 
        public List<Jugador> Jugadores { get; set; } 
        public Desempeno Desempeno {get;set;}
        
    }
}