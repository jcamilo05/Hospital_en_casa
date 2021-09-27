using System;
using System.Collections.Generic;
namespace TorneoDeFutbol.App.Dominio

{
     /// <summary>Class <c>Persona</c>
     /// Modela una Persona en general en el sistema 
     /// </summary>        
    public class Novedad
    {
        public int ID {get; set;}
        public Partido Partidos { get; set; }
        public TipoNovedad TipoDeNovedad {get; set;}
        public DateTime MinutoNovedad {get; set;}
        public List<Jugador> Jugadores { get; set; } 
 
    }

}