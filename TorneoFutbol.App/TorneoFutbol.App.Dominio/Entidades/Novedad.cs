using System;
using System.Collections.Generic;
namespace TorneoFutbol.App.Dominio

{
     /// <summary>Class <c>Persona</c>
     /// Modela una Persona en general en el sistema 
     /// </summary>        
    public class Novedad
    {
        // Tarjetas registradas en un partido
        public int ID{get;set;}
        public TipoNovedad TipoNovedad { get; set;}
        public Jugador Jugador { get; set; }
        public Partido Partido { get; set;}
        public DateTime Time {get;set;}
    }

}